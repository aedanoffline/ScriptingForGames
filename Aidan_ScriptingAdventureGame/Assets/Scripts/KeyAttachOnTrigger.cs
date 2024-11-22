using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KeyAttachOnTrigger : MonoBehaviour
{
    private TrapIDMatchBehavior trapIDMatchBehavior;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent = other.transform;
        }
        else
        {
            trapIDMatchBehavior = other.GetComponent<TrapIDMatchBehavior>();
            if (trapIDMatchBehavior != null)
            {
                if (other.CompareTag("KeyMatchTag") && trapIDMatchBehavior.isActivated)
                {
                    transform.parent = null;
                    Destroy(gameObject);
                }
            }
        }
    }
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent = other.transform;
        }
    }*/

    /*public void OnTriggerExit(Collider other)
    {
        trapIDMatchBehavior = other.GetComponent<TrapIDMatchBehavior>();
        if (trapIDMatchBehavior != null)
        {
            if (other.CompareTag("KeyMatchTag") && trapIDMatchBehavior.isActivated)
            {
                transform.parent = null;
                Destroy(gameObject);
            }
        }
    }*/
}
