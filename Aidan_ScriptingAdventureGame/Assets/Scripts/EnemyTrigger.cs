using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTrigger : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public AudioSource audioSource; // Reference to the AudioSource
    public float soundOffset = 0.03f;
    private Animator playerAnimator;
    private bool hitCooldown;

    private void Start()
    {
        //Call up audio source and change the time offset
        audioSource = GetComponent<AudioSource>();
        audioSource.time = soundOffset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hitCooldown)
        {
            StartCoroutine(DamageCooldown());
            triggerEvent.Invoke();
            playerAnimator = other.GetComponentInChildren<Animator>();
            playerAnimator.SetTrigger("HitTrigger");
            audioSource.Play();
        }
    }

    private IEnumerator DamageCooldown()
    {
        hitCooldown = true;
        yield return new WaitForSeconds(1f);
        hitCooldown = false;
    }
}