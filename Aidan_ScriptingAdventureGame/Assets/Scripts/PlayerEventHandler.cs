using UnityEngine;
using UnityEngine.Events;

public class PlayerEventHandler : MonoBehaviour
{
    public UnityEvent staminaEvent;
    public UnityEvent restEvent;
    public SimpleFloatData staminaData;
    private float restInterval = 0.08f;
    private float timer;
    
    private void Update()
    {
        JumpCheck();
        RestCheck();
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump"))
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
