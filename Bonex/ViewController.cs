using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MelonLoader;
using UnityEngine;

namespace Bonex
{
    [RegisterTypeInIl2Cpp]
    public class ViewController : MonoBehaviour, INotifyPropertyChanged
    {
        private bool _firstActivation = true;
        
        public ViewController(IntPtr ptr) : base(ptr)
        {
        }
        
        public virtual string Content { get; } = null!;

        public virtual string FallbackContent
        {
            get => @"";
        }

        private void Awake()
        {
            _firstActivation = true;
        }

        private void OnEnable()
        {
            DidActivate(_firstActivation);
            _firstActivation = false;
        }

        private void OnDisable()
        {
            DidDeactivate();
        }

        protected void ClearContents()
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        public virtual void DidActivate(bool firstActivation)
        {
            if (firstActivation)
            {
                ParseWithFallback();
            }
        }

        public virtual void DidDeactivate()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged = null!;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            } 
            catch(Exception e)
            {
                MelonLogger.Error(
                    $"Error invoking PropertyChanged for property '{propertyName}' on View Controller {name}\n{e}");
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void ParseWithFallback()
        {
            try
            {
                // TODO: Parse content
            } 
            catch (Exception e)
            {
                MelonLogger.Error($"Error parsing XML\n{e}");
                ClearContents();
                // TODO: Parse fallback
            }
        }
    }
}
