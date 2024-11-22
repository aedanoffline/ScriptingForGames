using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventHandler : MonoBehaviour
{
    public UnityEvent staminaEvent;
    public UnityEvent restEvent;
    public SimpleFloatData staminaData;
    public SimpleFloatData healthData;
    public CharacterController controller;
    private float restInterval = 0.08f;
    private float timer;
    public float minStamina = 0.2f;
    
    //public SimpleCharacterController characterController;

    /*private void Start()
    {
        characterController.GetComponentInParent<SimpleCharacterController>();
    }*/

    /*private void Update()
    {
        JumpCheck();
        RestCheck();
    }*/

    public void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && staminaData.value > minStamina && controller.isGrounded)
        {
            staminaEvent.Invoke();
        }
    }

    public void RestCheck()
    {
        timer += Time.deltaTime;
        
        bool NoKeyboardInput()
        {
            return !Input.anyKey;
        }

        if (NoKeyboardInput())
        {
            if (staminaData.value < 100)
            {
                if (timer >= restInterval)
                {
                    timer = 0f;
                    restEvent.Invoke();
                }
            }
        }
    }
}
