using UnityEngine;
using UnityEngine.InputSystem;

public class Drive : MonoBehaviour
{
    // SerializeField => Still visible in Inspector even though it's private
    [SerializeField] float steerSpeed = 0.1f; // Speed of the object
    [SerializeField] float moveSpeed = 0.1f; // Speed of the object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerInput = 0, moveInput = 0;

        // Handle steering input (horizontal)
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            steerInput = -1;
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            steerInput = 1;

        // Handle movement input (vertical)
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            moveInput = 1;
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            moveInput = -1;

        // Apply steering and movement
        float steerAmount = steerInput * steerSpeed * Time.deltaTime;
        float moveAmount = moveInput * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
