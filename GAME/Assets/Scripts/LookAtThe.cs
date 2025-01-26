using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class LookAtThe : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetInteger("Rotation", -1);
            //transform.SetPositionAndRotation(transform.position, new Quaternion(25, 0, 0,0));

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("Rotation", 1);
            //transform.SetPositionAndRotation(transform.position, new Quaternion(25, 0, 0, 0));
        }

    }

    void resetDirection()
    {
        anim.SetInteger("Rotation", 0);
    }
}
