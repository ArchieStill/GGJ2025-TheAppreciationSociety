using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtThe : MonoBehaviour
{
    public Animator anim;
    public GameObject gamecanvas;
    public GameObject ordercanvas;

    bool lookingDown = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        LookUp();
    }

    private void LateUpdate()
    {
        anim.SetInteger("Direction", 0);
    }

    public void LookUp()
    {
        if (lookingDown)
        {
            lookingDown = false;
            anim.SetInteger("Direction", 1);
            gamecanvas.SetActive(false);
            ordercanvas.SetActive(true);
        }
    }

    public void LookDown()
    {
        if (!lookingDown)
        { 
        lookingDown = true;
        anim.SetInteger("Direction", -1);
        gamecanvas.SetActive(true);
        ordercanvas.SetActive(false);
        }
    }
}
