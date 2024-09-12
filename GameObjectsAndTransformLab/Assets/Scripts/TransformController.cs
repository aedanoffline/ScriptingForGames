using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    public GameObject targetTransform;
    private void Update()
    {
        // Move the target GameObject
        var x = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(0, x, 0);
        Transform box = targetTransform.transform;
        
        box.position = p;
        
        // Rotate the target GameObject
        box.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        
        //Ping pong box scale
        box.localScale = new Vector3(box.localScale.x, x, box.localScale.z);
    }
}
