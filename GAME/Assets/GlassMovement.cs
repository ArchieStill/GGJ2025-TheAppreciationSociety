using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovement : MonoBehaviour
{
    public float MouseX = 1;
    public float MouseY = 1;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //rb.AddForce(new Vector3(mouse.x, transform.position.y, transform.position.z));
        //rb.position = new Vector3(mouse.x, rb.position.y, rb.position.z);
        //transform.position = new Vector3(mouse.x, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(new Vector3(-40, 0, 0));
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(new Vector3(40, 0, 0));
    }
}