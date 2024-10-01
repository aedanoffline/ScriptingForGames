using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0.5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 velocity;

    private void Start()
    {
        // Establishes component references
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        // Updates to ensure movement and z axis locking are available at all times
        MoveCharacter();
        KeepCharacterOnXAxis();
        ApplyGravity();
    }
    
    private void MoveCharacter()
    {
        // Assigns the X of the vector to the horizontal input axis
        movementVector.x = Input.GetAxis("Horizontal");
        // Multiplies this input by a factor of moveSpeed (defined above)
        movementVector *= (moveSpeed * Time.deltaTime);
        // Applies this newly updated vector to the character controller's move function
        controller.Move(movementVector);
        
        // Jumping
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            // Keep pushing slightly to ensure grounding
            velocity.y += (gravity / 10) * Time.deltaTime;
            //Debug.Log("I'm grounded!");
            //velocity.y = 0f;
        }
        
        // Apply the velocity to the controller
        controller.Move(velocity * Time.deltaTime);
    }

private void KeepCharacterOnXAxis()
   {
       // Assigns "0" to the transform properties of the script parent
       var currentPosition = thisTransform.position;
       currentPosition.z = 0f;
       thisTransform.position = currentPosition;
   }
}
