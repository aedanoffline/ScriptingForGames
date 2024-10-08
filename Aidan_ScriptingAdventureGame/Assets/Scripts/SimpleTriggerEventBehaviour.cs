using UnityEngine;
using UnityEngine.Events;

public class SimpleTriggerEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public AudioSource audioSource; // Reference to the AudioSource
    public float soundOffset = 0.03f;
    
    private void OnTriggerEnter(Collider other)
    {
        //Call up audio source and change the time offset
        audioSource.GetComponent<AudioSource>();
        audioSource.time = soundOffset;
        
        //Trigger event with debug message
        triggerEvent.Invoke();
        Debug.Log("Player interacted with the object!");
    }       
}
