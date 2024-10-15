using UnityEngine;
using UnityEngine.Events;

public class SpikeTrigger : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public AudioSource audioSource; // Reference to the AudioSource
    public float soundOffset = 0.03f;
    private Animator playerAnimator;
    //private GameObject actualPlayer;

    private void Start()
    {
        //Call up audio source and change the time offset
        audioSource = GetComponent<AudioSource>();
        audioSource.time = soundOffset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEvent.Invoke();
            //actualPlayer = other.GetChild(0);
            playerAnimator = other.GetComponentInChildren<Animator>();
            playerAnimator.SetTrigger("HitTrigger");
            Debug.Log("It's working...");
        }
    }       
}