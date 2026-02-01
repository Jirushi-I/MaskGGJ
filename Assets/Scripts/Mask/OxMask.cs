using UnityEngine;

public class OxMask : Mask
{
    [SerializeField] private Color oxFilterColors = new Color(1, 0, 0);

    [SerializeField][Range(0f, 1f)] private float visionRadius = 1.0f;
    [SerializeField][Range(0f, 0.5f)] private float edgeSoftness = 0.15f;
    [SerializeField][Range(0f, 20f)] private float blurAmount = 3f;
    [SerializeField][Range(0f, 1f)] private float centerAlpha = 0.7f;

    [SerializeField] private Sprite spriteMasks;


    protected override void ApplyCameraEffect() {
        if (filterColorImage == null) {
            Debug.LogWarning("Image not found");
            return;
        }

        imageMask.sprite = spriteMasks;
        filterColorImage.color = oxFilterColors;
        UpdateMaterial();
        Debug.Log(maskName + " is Applied");

    }

    protected override void RemoveCameraEffect() {
        if (filterColorImage == null)
            return;

        imageMask.sprite = imageDefaultMask;
        filterColorImage.color = defaultFilterColors;
        Debug.Log(maskName + " is removed");
    }

    protected override void UpdateMaterial() {
        if (visionMaterial != null) {
            visionMaterial.SetFloat("_VisionRadius", visionRadius);
            visionMaterial.SetFloat("_EdgeSoftness", edgeSoftness);
            visionMaterial.SetFloat("_BlurAmount", blurAmount);
            visionMaterial.SetFloat("_CenterAlpha", centerAlpha);
        }
    }
}