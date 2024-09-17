using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10f;  // Speed at which the camera moves

    void Update()
    {
        // Get the horizontal input from the left and right arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position based on the input and speed
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        // Apply the new position to the camera
        transform.position = newPosition;
    }
}
