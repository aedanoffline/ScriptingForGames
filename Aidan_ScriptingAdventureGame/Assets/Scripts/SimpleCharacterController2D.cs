using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f; // Increase for better jumping
    public LayerMask groundLayer;

    private Rigidbody2D controller;
    private Vector2 velocity;
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        controller = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    private bool IsGrounded()
    {
        // Get the bottom of the capsule collider
        Vector2 rayOrigin = (Vector2)transform.position + (Vector2)capsuleCollider.offset + new Vector2(0, capsuleCollider.size.y / 2 + 0.5f); // Adjusted position above the player
        return Physics2D.Raycast(rayOrigin, Vector2.down, 1f, groundLayer);
    }
    
    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        bool isGrounded = IsGrounded();
        Debug.Log("Is Grounded: " + isGrounded);
    }

    private void MoveCharacter()
    {
        // Get horizontal input
        float moveInput = Input.GetAxis("Horizontal");
        velocity.x = moveInput * moveSpeed;

        // Jumping
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics2D.gravity.y);
        }

        // Apply the updated velocity to the Rigidbody2D
        controller.velocity = velocity;
    }

    private void ApplyGravity()
    {
        // Apply gravity when not grounded
        if (!IsGrounded())
        {
            velocity.y += Physics2D.gravity.y * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
            Debug.Log("touching ground layer");
        }
        
        // Apply the velocity to the controller here
        controller.velocity = velocity;
    }

    private void OnDrawGizmos()
    {
        if (capsuleCollider == null) return;

        Gizmos.color = Color.red;
        Vector2 rayOrigin = (Vector2)transform.position + (Vector2)capsuleCollider.offset + new Vector2(0, capsuleCollider.size.y / 2 + 0.5f); // Adjusted position above the player
        Gizmos.DrawLine(rayOrigin, rayOrigin + Vector2.down * 1f); // Ray pointing downwards
    }
}