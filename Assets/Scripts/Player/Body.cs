using UnityEngine;
using UnityEngine.InputSystem;

public class Body : MonoBehaviour
{
    CharacterController controller;

    Transform head;
    Vector3 movement;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        head = GetComponentInChildren<Head>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        controller.SimpleMove(head.TransformDirection(movement));
    }

    public void Move(InputAction.CallbackContext context) 
    {
        Vector2 controlDirection = context.ReadValue<Vector2>();
        movement = new Vector3(controlDirection.x, 0, controlDirection.y);
    }
}
