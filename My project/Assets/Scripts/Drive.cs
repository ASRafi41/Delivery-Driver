using UnityEngine;
using UnityEngine.InputSystem;

public class Drive : MonoBehaviour
{
    // SerializeField => Still visible in Inspector even though it's private
    [SerializeField] float steerSpeed = 200f; // Speed of the object
    [SerializeField] float moveSpeed = 10f; // Speed of the object
    [SerializeField] float BoostSpeed = 20f; // Speed boost when pressing space]
    [SerializeField] float SlowSpeed = 10f; // Speed when slowing down

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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("!!!!!!!!!!!!!!!!");
        moveSpeed = SlowSpeed; // Decrease speed when colliding with an object
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost")
        {
            moveSpeed = BoostSpeed; // Increase speed when entering boost area
            Debug.Log("Boost activated!");
        }
        //else if(collision.tag == "Slow")
        //{
        //    moveSpeed = SlowSpeed; // Decrease speed when entering slow area
        //    Debug.Log("Slow down activated!");
        //}
    }

}
