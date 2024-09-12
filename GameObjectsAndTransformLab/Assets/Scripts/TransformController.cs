using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    /* public GameObject targetTransform;
    private void Update()
    {
        // Move the target GameObject
        var x = Mathf.PingPong(Time.time, 1);
        var y = Mathf.PingPong(Time.time, 1);
        var p = new Vector3(Mathf.Cos(x)*4, Mathf.Sin(y)*4, 0);
        Transform box = targetTransform.transform;
        
        box.position = p;
        
        // Rotate the target GameObject
        box.Rotate(new Vector3(30, 30, 0) * (3*Time.deltaTime));
        
        //Ping pong box scale
        box.localScale = new Vector3(box.localScale.x, x, box.localScale.z);
    } */
    
    // Assignable object variable
    public GameObject targetObject;
    
    // Object mover variables
    public float speed = 18f;
    public float distance = 5f;
    
    // Object rotator variables
    public float rotationSpeed = 350f;
    
    // Object scaler variables
    public float pulseSpeed = 4f;
    public float maxScale = 4f;
    public float minScale = 0.5f;

    void Update()
    {
        // Shorthand for target object transformations
        Transform box = targetObject.transform;
        
        // PingPong variables for movement and scaling
        float move = Mathf.PingPong(Time.time * speed, distance);
        float scale = Mathf.PingPong(Time.time * pulseSpeed, maxScale - minScale) + minScale;
        
        // Object transformations
        box.position = new Vector3(move, Mathf.Sin(move), Mathf.Cos(move));
        box.Rotate(0, rotationSpeed * Time.deltaTime, 2 * rotationSpeed * Time.deltaTime);
        box.localScale = new Vector3(scale, scale, scale);
    }
}
