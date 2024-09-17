using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReactions : MonoBehaviour
{
    // Collision detection
    void OnCollisionEnter(Collision other)
    {
        // Only change the color and make a sound if the collider in question has tag "Ball"
        if (other.gameObject.CompareTag("Ball"))
        {
            Color currentColor = GetComponent<Renderer>().material.color;
            currentColor = new Color(
                Mathf.Clamp01(currentColor.r + 0.1f), 
                Mathf.Clamp01(currentColor.g - 0.1f), 
                Mathf.Clamp01(currentColor.b - 0.1f)
            );;
            GetComponent<Renderer>().material.color = currentColor;
        }
        
    }
}
