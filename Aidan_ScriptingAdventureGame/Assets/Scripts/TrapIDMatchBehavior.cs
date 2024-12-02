using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TrapIDMatchBehavior : MonoBehaviour
{
    public Id ExpectingId;
    public UnityEvent matchEvent, noMatchEvent;
    private Animator animator;
    public bool isActivated = true;
    private Animator playerAnimator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherID = other.GetComponent<SimpleIDBehavior>();
            
        if (otherID != null && otherID.id == ExpectingId && isActivated)
        {
            matchEvent.Invoke();
            Destroy(other.gameObject);
            isActivated = false;
            animator.SetTrigger("KeyMatchTrigger");
            //Debug.Log("Matched ID: " + ExpectingId);
        }
        else
        {
            if (other.CompareTag("Player") && isActivated)
            {
                noMatchEvent.Invoke();
                playerAnimator = other.GetComponentInChildren<Animator>();
                playerAnimator.SetTrigger("HitTrigger");
            }
            //Debug.Log("No Match: " + ExpectingId);
        }
    }
}
