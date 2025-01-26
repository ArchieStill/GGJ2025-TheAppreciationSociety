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
        anim.SetInteger("Direction", 1);
        gamecanvas.SetActive(false);
        ordercanvas.SetActive(true);
    }

    public void LookDown()
    {
        anim.SetInteger("Direction", -1);
        gamecanvas.SetActive(true);
        ordercanvas.SetActive(false);
    }
}
