using System;
using UnityEngine;
using UnityEngine.Events;

public class SimpleCherryEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;
    private bool alreadyActivated = false;
    private GameObject scoreObj;
    private Animator scoreAnimator;

    private void Start()
    {
        scoreObj = GameObject.FindGameObjectWithTag("ScoreTag");
        scoreAnimator = scoreObj.GetComponent<Animator>();
    }

    private void CollectCherry()
    {
        // Start a coroutine to wait for the animation to finish
        StartCoroutine(DestroyCherryAfterAnimation());
    }

    private System.Collections.IEnumerator DestroyCherryAfterAnimation()
    {
        float animationDuration = 0.5f;
        
        // Wait for the duration of the animation
        yield return new WaitForSeconds(animationDuration);

        // Destroy the coin object
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //animator.SetTrigger("CherryCollected");
        //Destroy(gameObject);
        if (!alreadyActivated)
        {
            alreadyActivated = true;
            scoreAnimator.SetTrigger("ScoreShake");
            triggerEvent.Invoke();
        }
        CollectCherry();
    }
}
