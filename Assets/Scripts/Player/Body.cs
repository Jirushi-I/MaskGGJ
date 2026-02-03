using UnityEngine;
using UnityEngine.InputSystem;

public class Body : MonoBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float sprintMultiplier = 2f;

    CharacterController controller;
    Transform head;
    Vector3 movement;
    bool isSprinting = false;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        head = GetComponentInChildren<Head>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null && controller.enabled) {
            float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;
            controller.SimpleMove(head.TransformDirection(movement) * currentSpeed);
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
}
