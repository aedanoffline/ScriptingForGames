using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
   public float moveSpeed = 5f;
   private CharacterController controller;
   private Transform thisTransform;
   private Vector3 movementVector = Vector3.zero;

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
   }

   private void MoveCharacter()
   {
       // Assigns the X of the vector to the horizontal input axis
       movementVector.x = Input.GetAxis("Horizontal");
       // Multiplies this input by a factor of moveSpeed (defined above)
       movementVector *= (moveSpeed * Time.deltaTime);
       // Applies this newly updated vector to the character controller's move function
       controller.Move(movementVector);
   }

   private void KeepCharacterOnXAxis()
   {
       // Assigns "0" to the transform properties of the script parent
       var currentPosition = thisTransform.position;
       currentPosition.z = 0f;
       thisTransform.position = currentPosition;
   }
}
