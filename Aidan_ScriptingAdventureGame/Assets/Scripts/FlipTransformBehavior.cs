using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTransformBehavior : MonoBehaviour
{
    public KeyCode key1 = KeyCode.LeftArrow, key2 = KeyCode.RightArrow;
    //public KeyCode key3 = KeyCode.A, key4 = KeyCode.D;
    public float direction1 = 0, direction2 = 180;

    private void Update()
    {
        if (Input.GetKeyDown(key1))
        {
            transform.rotation = Quaternion.Euler(0, direction2, 0);
        }
        
        if (!Input.GetKeyDown(key2)) return;
        transform.rotation = Quaternion.Euler(0, direction1, 0);
        
        /*if (Input.GetKeyDown(key1) || Input.GetKeyDown(key3))
        {
            transform.rotation = Quaternion.Euler(0, direction1, 0);
        }
        
        if (Input.GetKeyDown(key2) || Input.GetKeyDown(key4))
        {
            transform.rotation = Quaternion.Euler(0, direction2, 0);
        }*/
        
    }
        
    

}
