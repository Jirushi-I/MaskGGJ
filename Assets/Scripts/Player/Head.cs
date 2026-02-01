using System;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class Head : MonoBehaviour
{
    CharacterController controller;
    
    float yaw;
    float pitch;

    public float sensitivity = 1f;
    public float minPitch = 45f;
    public float maxPitch = 45f;

    void Awake()
    {
        controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Rotate(InputAction.CallbackContext context)
    {
        if (controller.enabled == false) return;


        Vector2 input = context.ReadValue<Vector2>() * sensitivity * Time.deltaTime;

        yaw += input.x;
        pitch -= input.y;
        pitch = Mathf.Clamp(pitch, -minPitch, maxPitch);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
