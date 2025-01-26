using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovementScript : MonoBehaviour
{
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

    public float mouseInputMultiplier = 1.0f;
    
    // Current movement velocity on XZ plane
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        // Locks cursor to the screen
        Cursor.lockState = CursorLockMode.Locked;
        
        // Hide the cursor while locked
        Cursor.visible = false;
    }

    private void Update()
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

        // Read mouse input, adjust with sensitivity
        float inputX = mouseInputMultiplier * Input.GetAxis("Mouse X");
        float inputZ = mouseInputMultiplier * Input.GetAxis("Mouse Y");

        // Some fancy physics to add acceleration to velocity
        Vector3 inputVector = new Vector3(inputX, 0f, inputZ);
        velocity += inputVector * acceleration * Time.deltaTime;

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

        // Apply movement physics
        transform.position += velocity * Time.deltaTime;

        // Keep y fixed if needed, e.g. if the glass is always at y=1.0:
        // transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        
        
        // Tilting is around the local X and Z axes, ignoring Y
        // The tilt angle is proportional to the speed

        float speed = velocity.magnitude;
        float tiltAngle = Mathf.Min(speed * tiltFactor, maxTiltAngle);

        // If not moving, reset tilt to upright
        if (speed < 0.01f)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.identity, 
                Time.deltaTime * 5f
            );
        }
        else
        {
            // Glass leans *backward* relative to travel direction
            // moving along +X, tilts around Z axis
            Vector3 moveDir = velocity.normalized;
            Vector3 tiltAxis = Vector3.Cross(moveDir, Vector3.up);
            
            // tiltAxis points left or right of velocity, invert cross to tilt *into* the turn
            Quaternion targetRotation = Quaternion.AngleAxis(tiltAngle, tiltAxis) * Quaternion.identity;

            // Smoothly rotate towards this tilt
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * 5f
            );
        }
    }
}
