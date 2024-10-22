using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class SimpleCherryEventBehaviour : MonoBehaviour
{
    public UnityEvent triggerEvent;
    
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEvent.Invoke();
        Destroy(gameObject);
    }
}
