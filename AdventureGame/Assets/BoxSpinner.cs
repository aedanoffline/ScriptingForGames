using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 100f;

    void Update()
    {
        // Calculate the amount to rotate based on time and speed
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Apply the rotation to the sprite
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
