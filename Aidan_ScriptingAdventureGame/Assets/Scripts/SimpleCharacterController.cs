using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 0.5f;
    public float gravity = -9.81f;
    public GameObject deathScreen;
    
    private PlayerEventHandler eventHandler;
    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 movementVector = Vector3.zero;
    private bool locked;
    private Vector3 lockedPosition;
    private SpriteRenderer spriteRenderer;

    // Animation Variables
    private AudioSource[] audioSources;
    private bool walkCheck;
    private bool groundCheck = true;
    
    //private double staminaMinimum = 0.2;
    //private Vector3 velocity;

    private void Start()
    {
        // Establishes component references
        controller = GetComponent<CharacterController>();
        eventHandler = GetComponentInChildren<PlayerEventHandler>();
        audioSources = GetComponents<AudioSource>();
        thisTransform = transform;
    }

    private void Update()
    {
        // Updates to ensure movement and z axis locking are available at all times
        MoveCharacter();
        KeepCharacterOnXAxis();
        ApplyGravity();
        eventHandler.RestCheck();
        DeathCheck();
    }

    private void DeathCheck()
    {
        if (eventHandler.healthData.value <= 0)
        {
            if (!locked)
            {
                locked = true;
                spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
                lockedPosition = thisTransform.position;
            }
            spriteRenderer.enabled = false;
            transform.position = lockedPosition;
            foreach (AudioSource a in audioSources)
            {
                a.volume = 0f;
            }
            deathScreen.SetActive(true);
        }
    }
    
    public void MoveCharacter()
    {
        // Assigns the X of the vector to the horizontal input axis
        movementVector.x = Input.GetAxis("Horizontal") * moveSpeed;
        // Multiplies this input by a factor of moveSpeed (defined above)
        //movementVector.x *= (moveSpeed * Time.deltaTime);
        // Applies this newly updated vector to the character controller's move function
        //controller.Move(movementVector);

        //Sound Checker & Player
        if (movementVector.x != 0f && !walkCheck) // If the player begins walking from a stationary position
        {
            // Plays the sound only once by flipping the walk bool
            walkCheck = true;
            audioSources[0].Play();
        }
        else if (movementVector.x == 0f) // If the player isn't moving horizontally
        {
            // Stops the sound and flips the walk bool back to an available state
            audioSources[0].Stop();
            walkCheck = false;
        }
        
        if (!controller.isGrounded) // If the player is in the air
        {
            // Stop the walk sound and set the ground bool to false
            audioSources[0].Stop();
            groundCheck = false;
        }
        else if (controller.isGrounded && !groundCheck) // If the player just landed from a jump or a fall
        {
            // Flip the ground bool so that this if statement can only trigger once
            groundCheck = true;
            audioSources[2].Play();
            if (walkCheck) // If the player just landed and is still holding "A" or "D"
            {
                // Flip the walk bool back to an available state so that the walk sound can trigger again after landing
                walkCheck = false;
            }
        }
        
        // Jumping
        if (Input.GetButtonDown("Jump") && eventHandler.staminaData.value > eventHandler.minStamina && controller.isGrounded)
        {
            //Debug.Log("I'm grounded");
            movementVector.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            eventHandler.JumpCheck();
            audioSources[1].Play();
        }
    }

    public void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!controller.isGrounded)
        {
            movementVector.y += gravity * Time.deltaTime;
        }
        else
        {
            // Keep pushing slightly to ensure grounding
            movementVector.y += (gravity / 100) * Time.deltaTime;
            //Debug.Log("I'm grounded!");
            //velocity.y = 0f;
        }
        
        // Apply the velocity to the controller
        controller.Move(movementVector * Time.deltaTime);
    }

    public void KeepCharacterOnXAxis()
    {
       // Assigns "0" to the transform properties of the script parent
       var currentPosition = thisTransform.position;
       currentPosition.z = 0f;
       thisTransform.position = currentPosition;
    }
}
