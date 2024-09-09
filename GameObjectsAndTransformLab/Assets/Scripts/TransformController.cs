using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    public GameObject TargetTransform;
    private void Update()
    {
        // Move the target GameObject
        var x = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(0, x, 0);
        TargetTransform.transform.position = p;
        
        // Rotate the target GameObject
        TargetTransform.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        
        //Ping pong box scale
        TargetTransform.transform.localScale = new Vector3(1, x, 1);
    }
}
