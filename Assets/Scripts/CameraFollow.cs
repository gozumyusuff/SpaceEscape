using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //TODO: Serialize
    public Transform target;  
    public float smoothing = 0.125f; 
    public Vector3 offset; 

    void FixedUpdate()
    {
        if (target == null)
            return;
        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);
        transform.position = smoothedPosition;
    }
}


