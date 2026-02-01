using UnityEngine;

public class LionMask : Mask
{
    [SerializeField] private Color lionFilterColors = new Color(0.81f,0.85f,0.25f);

    [SerializeField][Range(0f, 1f)] private float visionRadius = 0.4f;
    [SerializeField][Range(0f, 0.5f)] private float edgeSoftness = 0.14f;
    [SerializeField][Range(0f, 20f)] private float blurAmount = 0f;
    [SerializeField][Range(0f, 1f)] private float centerAlpha = 0.1f;

    [SerializeField] private Sprite spriteMasks;


    protected override void ApplyCameraEffect() {
        if (filterColorImage == null) {
            Debug.LogWarning("Image not found");
            return;
        }

        imageMask.sprite = spriteMasks;
        filterColorImage.color = lionFilterColors;
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
