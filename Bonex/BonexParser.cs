using System;
using MelonLoader;
using UnityEngine;

namespace Bonex
{
    public class BonexParser : MonoBehaviour
    {
        private static BonexParser s_instance = null!;
        private static object s_lock = new();
        private static bool s_applicationIsQuitting = false;
        
        public BonexParser(IntPtr ptr) : base(ptr)
        {
        }

        public static bool IsAvailable
        {
            get => !s_applicationIsQuitting && s_instance != null;
        }

        public static BonexParser Instance
        {
            get
            {
                if (s_applicationIsQuitting)
                {
                    MelonLogger.Warning(
                        "BonexParser already destroyed on application quit. Won't create again - returning null.");
                    return null!;
                }

                lock (s_lock)
                {
                    if (s_instance != null)
                        return s_instance;
                    
                    s_instance = FindObjectOfType<BonexParser>();

                    if (FindObjectsOfType<BonexParser>().Length > 1)
                    {
                        MelonLogger.Error(
                            "There are multiple BonexParser instances - this should never happen.");
                        return s_instance;
                    }

                    if (s_instance != null)
                        return s_instance;
                        
                    GameObject target = new();
                    s_instance = target.AddComponent<BonexParser>();
                    target.name = nameof(BonexParser);

                    return s_instance;
                }
            }
        }

        private void OnEnable()
        {
            DontDestroyOnLoad(this);
        }

        private void OnDestroy()
        {
            s_applicationIsQuitting = true;
        }
    }
}
