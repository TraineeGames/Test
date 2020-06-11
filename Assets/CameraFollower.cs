using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public Vector3 velocity;
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, 0.125f);
    }
}