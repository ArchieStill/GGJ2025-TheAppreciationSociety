using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody bobaBody;


    void Start()
    {
        bobaBody = GetComponent<Rigidbody>();
        var force = new Vector3(Random.Range(0.2f, 1.0f), 1, Random.Range(0.2f, 1.0f));
        bobaBody.AddForce(force);
    }
}