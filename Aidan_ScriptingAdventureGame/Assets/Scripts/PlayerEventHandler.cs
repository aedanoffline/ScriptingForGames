using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventHandler : MonoBehaviour
{
    public UnityEvent staminaEvent;
    public UnityEvent restEvent;
    public SimpleFloatData staminaData;
    private float restInterval = 0.08f;
    private float timer;
    public CharacterController controller;

    /*private void Start()
    {
        controller.GetComponentInParent<CharacterController>();
    }*/

    private void Update()
    {
        JumpCheck();
        RestCheck();
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && staminaData.value > 0 && controller.isGrounded)
        {
            staminaEvent.Invoke();
        }
    }

    private void RestCheck()
    {
        timer += Time.deltaTime;
        
        bool NoKeyboardInput()
        {
            return !Input.anyKey;
        }

        if (NoKeyboardInput())
        {
            if (staminaData.value <= 1)
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
