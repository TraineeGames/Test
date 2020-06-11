using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Vector3 startPosition, startRotation;
    public Vector3 firstPosition;
    public Vector3 lastPosition;
    public Image powerBar;
    public float maxPower = 900;
    private Rigidbody rb;
    private Vector3 force;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.AddForce(-force);
        }

        if (Input.GetMouseButton(0))
        {
            lastPosition = Input.mousePosition;
            force = lastPosition - firstPosition;
            force.z = force.y;
            force.y = 0;
            
            var tempMag = force.magnitude;
            force.Normalize();
            tempMag = Mathf.Clamp(tempMag, 0, maxPower);
            force *= tempMag;
            powerBar.fillAmount = force.magnitude / maxPower;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            transform.position = startPosition;
            transform.eulerAngles = startRotation;
        }
    }
}