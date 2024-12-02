using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KeyAttachOnTrigger : MonoBehaviour
{
    private Rigidbody rigidBody;
    private bool held;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !held)
        {
            held = true;
            rigidBody = gameObject.GetComponent<Rigidbody>();
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
            transform.parent = other.transform;
        }
    }
}
