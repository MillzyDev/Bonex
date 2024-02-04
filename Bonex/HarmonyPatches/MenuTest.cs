using HarmonyLib;
using SLZ.Bonelab;
using UnityEngine;

namespace Bonex.HarmonyPatches;

[HarmonyPatch(typeof(GameControl_MenuVoidG114))]
[HarmonyPatch(nameof(GameControl_MenuVoidG114.Start))]
public static class MenuTest
{
    [HarmonyPrefix]
    // ReSharper disable once UnusedMember.Local
    private static void Prefix()
    {
        var canvas = BonelabUI.CreateCanvas();
        var layout = BonelabUI.CreateVerticalLayoutGroup(canvas.transform);
        BonelabUI.CreateText(layout.transform, "Test Text", false, new Vector2(0f, 0f), new Vector2(60f, 10f));
    }
}