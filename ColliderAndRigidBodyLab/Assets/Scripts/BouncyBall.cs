using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    // How strong the bounce is
    public float bounceForce = 3f;
    
    // Shrinking mulitplier
    public float shrinkFactor = 0.9f;
    
    private void OnCollisionEnter(Collision collision)
    {
        // On collision, apply upward force that follows bounceForce
        GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        
        // On collision, shrink the object by the shrink factor.
        transform.localScale *= shrinkFactor;
    }
}
