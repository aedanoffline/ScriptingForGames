using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        //Trigger event with debug message
        triggerEvent.Invoke();
        Debug.Log("Player interacted with the object!");
    }       
}
