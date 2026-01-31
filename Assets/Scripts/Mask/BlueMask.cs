using UnityEngine;

public class BlueMask : Mask {

    [SerializeField] private Color blueFilterColors = Color.blue;
    [SerializeField] private float filterIntensity = 0.5f;
    

    protected override void ApplyCameraEffect() {
        if (filterColorImage == null) {
            Debug.LogWarning("Image not found");
            return;
        }

        Color targetColor = Color.Lerp(defaultFilterColors, blueFilterColors, filterIntensity);
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
