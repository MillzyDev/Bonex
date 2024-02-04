using System.Linq;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bonex;

public static class BonelabUI
{
    private const string CanvasName = "BonexUICanvas";
    private const string TextName = "BonexUIText";
    private const string VerticalLayoutGroupName = "BonexUIVerticalLayoutGroup";

    private static TMP_FontAsset? _primaryFont;

    private static TMP_FontAsset GetPrimaryFont()
    {
        if (!_primaryFont)
            _primaryFont = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().FirstOrDefault(x => x.name == "arlon-medium SDF");

        if (_primaryFont) return _primaryFont!;
        
        MelonLogger.Error("Unable to find font. It is likely you're trying to to this somewhere that you shouldn't be.");
        return null!;

    }
    
    public static GameObject CreateCanvas()
    {
        var gameObject = new GameObject(CanvasName)
        {
            layer = 5 // UI Layer
        };
        var canvas = gameObject.AddComponent<Canvas>();
        canvas.additionalShaderChannels =
            AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2;
        canvas.sortingOrder = 4; // Make UI render over other objects.

        // make the UI elements not be massive
        var scaler = gameObject.AddComponent<CanvasScaler>();
        scaler.scaleFactor = 1f;
        scaler.dynamicPixelsPerUnit = 3.44f;
        scaler.referencePixelsPerUnit = 10f;

        var rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        return gameObject;
    }

    public static TextMeshProUGUI CreateText(Transform parent, string text, bool italic, Vector2 anchoredPosition, Vector2 sizeDelta)
    {
        var gameObject = new GameObject(TextName);
        gameObject.SetActive(false); // this is to ensure Start doesnt run until everything is ready

        var textMesh = gameObject.AddComponent<TextMeshProUGUI>();
        var rectTransform = textMesh.rectTransform;
        rectTransform.SetParent(parent, false);

        TMP_FontAsset font = GetPrimaryFont();
        textMesh.font = font;
        textMesh.fontSharedMaterial = font.material; // pretty sure this should be fine

        if (italic)
            textMesh.fontStyle = FontStyles.Italic;

        textMesh.text = text;
        textMesh.fontSize = 4f;
        textMesh.color = Color.white;
        textMesh.richText = true;

        rectTransform.anchorMin = new Vector2(.5f, .5f);
        rectTransform.anchorMax = new Vector2(.5f, .5f);
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = sizeDelta;

        gameObject.AddComponent<LayoutElement>();
        
        gameObject.SetActive(true);
        return textMesh;
    }

    public static VerticalLayoutGroup CreateVerticalLayoutGroup(Transform parent)
    {
        var gameObject = new GameObject(VerticalLayoutGroupName);
        var layout = gameObject.AddComponent<VerticalLayoutGroup>();

        var contentSizeFitter = gameObject.AddComponent<ContentSizeFitter>();
        contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

        var rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.SetParent(parent, false);
        rectTransform.anchorMin = new Vector2(0f, 0f);
        rectTransform.anchorMax = new Vector2(1f, 1f);
        rectTransform.sizeDelta = new Vector2(0f, 0f);

        gameObject.AddComponent<LayoutElement>();
        return layout;
    }
}