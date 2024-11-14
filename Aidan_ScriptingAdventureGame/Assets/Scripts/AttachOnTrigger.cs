using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AttachOnTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.parent = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KeyMatchTag"))
        {
            transform.parent = null;
        }
    }
}
