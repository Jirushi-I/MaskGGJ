using UnityEngine;

public class Deer : Mask {

    [SerializeField] private Color deerFilterColors = new Color(1,1,1);
    [SerializeField] private float filterIntensity = 0.6f;
    

    protected override void ApplyCameraEffect() {
        if (filterColorImage == null) {
            Debug.LogWarning("Image not found");
            return;
        }

        Color targetColor = Color.Lerp(defaultFilterColors, deerFilterColors, filterIntensity);
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
