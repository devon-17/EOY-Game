using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    // The character controller component
    CharacterController controller;

    // The character's movement speed
    public float movementSpeed = 5f;

    // The character's jump force
    public float jumpForce = 10f;

    // Use this for initialization
    void Start()
    {
        // Get the character controller component
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the character's movement input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        // Move the character in the specified direction
        controller.Move(direction * movementSpeed * Time.deltaTime);

        // Check if the player wants to jump
        if (Input.GetButtonDown("Jump"))
        {
            // Make the character jump
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
        }
    }
}
