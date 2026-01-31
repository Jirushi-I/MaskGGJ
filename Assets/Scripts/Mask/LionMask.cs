using UnityEngine;

public class GreenMask : Mask
{
    [SerializeField] private Color lionFilterColors = new Color(0.81f,0.85f,0.25f);
    [SerializeField] private float filterIntensity = 0.6f;


    protected override void ApplyCameraEffect() {
        if (filterColorImage == null) {
            Debug.LogWarning("Image not found");
            return;
        }

        Color targetColor = Color.Lerp(defaultFilterColors, lionFilterColors, filterIntensity);
        filterColorImage.color = targetColor;

        Debug.Log(maskName + " is Applied");

    }
    protected override void RemoveCameraEffect() {
        if (filterColorImage == null)
            return;

        filterColorImage.color = defaultFilterColors;

        Debug.Log(maskName + " is removed");
    }
}
