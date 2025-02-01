using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovementScriptRB : MonoBehaviour
{
    public bool captureCursor = true;
    
    // How quickly the glass accelerates in response to mouse movement.
    public float acceleration = 20f;

    // Friction or drag that slows down movement over time.
    public float damping = 5f;

    // Maximum speed the glass can reach.
    public float maxSpeed = 5f;
    
    // How much the glass tilts (in degrees) per unit of movement speed.
    public float tiltFactor = 10f;
    
    // Maximum tilt angle
    public float maxTiltAngle = 45f;

    // Sensitivity Setting
    public float mouseInputMultiplier = 1.0f;

    public float forcesMultiplier = 1.0f;
    
    // Current movement velocity on XZ plane
    private Vector3 velocity = Vector3.zero;
    
    private Rigidbody rb;
    
    // Start is called before the first frame update

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (captureCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if (mouseWheel > 0)
        {
            mouseInputMultiplier += 0.5f;
        }
        else if (mouseWheel < 0)
        {
            mouseInputMultiplier -= 0.5f;
        }
    }

    private void FixedUpdate()
    {
        // Read mouse input, adjust with sensitivity
        float inputX = mouseInputMultiplier * Input.GetAxis("Mouse X");
        float inputZ = mouseInputMultiplier * Input.GetAxis("Mouse Y");

        Vector3 inputVector = new Vector3(inputX, 0f, inputZ);
        velocity = inputVector * acceleration * Time.deltaTime;
        
        // We gotta prevent that glass from speedin' 
        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        
        // Damping, simulates friction slowing things down over time
        if (velocity.magnitude > 0.001f)
        {
            // Lerp velocity each frame
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping * Time.deltaTime);
        }

        // physics directly applied to rigidbody
        Vector3 forcesVector = (velocity * forcesMultiplier) * Time.deltaTime;
        rb.velocity = forcesVector;
    }
}
