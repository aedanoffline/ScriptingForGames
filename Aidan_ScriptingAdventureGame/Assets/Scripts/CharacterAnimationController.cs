using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator;
    public PlayerEventHandler eventHandler;
    
    private void Start()
    {
        // I'm assuming this calls up the animator component
        animator = GetComponent<Animator>();
        eventHandler = FindObjectOfType<PlayerEventHandler>();
        //eventHandler = GetComponent<PlayerEventHandler>();
    }

    private void Update()
    {
        HandleAnimations();
    }
    
    private void HandleAnimations()
    {
        //Run and idle
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetTrigger("RunTrigger");   
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }
        
        //Jump
        if (Input.GetButtonDown("Jump") && eventHandler.staminaData.value > eventHandler.minStamina)
        {
            animator.SetTrigger("JumpTrigger");
        }
        
        //Wall Jump temp trigger
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WallJumpTrigger");
        }
        
        //Fall temp trigger
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FallTrigger");
        }
        
        //Hit temp trigger
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetTrigger("HitTrigger");
        }
        
        //Double jump temp trigger
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("DoubleJumpTrigger");
        }
    }
}
