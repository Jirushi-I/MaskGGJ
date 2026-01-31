using UnityEngine;

public class RedMask : Mask
{
    [SerializeField] private Color oxFilterColors = new Color(1,0,0);
    [SerializeField] private float filterIntensity = 0.7f;


    protected override void ApplyCameraEffect() {
        if (filterColorImage == null) {
            Debug.LogWarning("Image not found");
            return;
        }

        Color targetColor = Color.Lerp(defaultFilterColors, oxFilterColors, filterIntensity);
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
