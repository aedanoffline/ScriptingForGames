using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector3 move = new Vector3(moveX, moveY, 0f);

        // Move the camera
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
