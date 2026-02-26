
using UnityEngine;
using UnityEngine.InputSystem;

public class Head : MonoBehaviour {

    [SerializeField] private CharacterController player;
    [SerializeField] private float sensitivity = 1f;
    [SerializeField] private float minPitch = 45f;
    [SerializeField] private float maxPitch = 45f;

    private float yaw;
    private float pitch;

    private void Start() {
        SyncRotationValues();
    }

    public void Rotate(InputAction.CallbackContext context)
    {
        if (player.enabled == false) return;

        Vector2 input = context.ReadValue<Vector2>() * sensitivity * Time.deltaTime;

        yaw += input.x;
        pitch -= input.y;
        pitch = Mathf.Clamp(pitch, -minPitch, maxPitch);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    // Méthode pour synchroniser yaw/pitch avec la rotation actuelle
    public void SyncRotationValues() {
        Vector3 currentRotation = transform.eulerAngles;
        yaw = currentRotation.y;
        pitch = currentRotation.x;

        // Normalise pitch
        if (pitch > 180) pitch -= 360;
    }
}
