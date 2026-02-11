using UnityEngine;
using UnityEngine.InputSystem;

public class Body : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private CharacterController player;
    [SerializeField] private Transform head;
    [SerializeField] private Head headScript;

    Vector3 movement;
    bool isSprinting = false;

    private void Awake() {
        ActiveCharacterController(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player != null && player.enabled) {
            float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;
            player.SimpleMove(head.TransformDirection(movement) * currentSpeed);
        }
    }

    public void Move(InputAction.CallbackContext context) 
    {
        Vector2 controlDirection = context.ReadValue<Vector2>();
        movement = new Vector3(controlDirection.x, 0, controlDirection.y);
    }

    public void Sprint(InputAction.CallbackContext context) {
       
        if (context.performed) // Button pressed
        {
            isSprinting = true;
        } else if (context.canceled) // Button release
        {
            isSprinting = false;
        }
    }

    public void ActiveCharacterController(bool isActive) {
        Debug.Log("isActive" + isActive);
        player.enabled = isActive;

        if (isActive && headScript != null) 
            headScript.SyncRotationValues();
    }
}
