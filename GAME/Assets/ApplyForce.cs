using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody bobaBody;


    void Start()
    {
        bobaBody = GetComponent<Rigidbody>();
        var force = new Vector3(Random.Range(1, 6), 1, Random.Range(1, 6));
        bobaBody.AddForce(force);
    }
}