using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KeyAttachOnTrigger : MonoBehaviour
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
            Destroy(gameObject);
        }
    }
}
