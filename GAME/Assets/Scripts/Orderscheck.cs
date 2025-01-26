using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderscheck : MonoBehaviour
{
    public GameObject IngredientChecker;
    public GameObject FillChecker;
    public Animator anim;

    private bool[] Contents = new bool[5];
    private bool[] Order = new bool[5];

    private int OrderNum = 0;
    private bool[] Order1 = {true, false, true, false, true};
    private bool[] Order2 = {true, true, false, true, false};
    private bool[] Order3 = {true, true, true, false, true};

    void Start()
    {
        anim = GetComponent<Animator>();
        SetOrder();
    }

    void SetOrder()
    {
        if (OrderNum == 0)
        {
            Order = Order1;
        }
        else if (OrderNum == 1)
        {
            Order = Order2;
        }
        else if (OrderNum == 2)
        {
            Order = Order3;
        }
        OrderNum++;
    }

    void Update()
    {
        Contents = IngredientChecker.GetComponent<IngredientCheck>().ReturnContents();
        bool pass = true;
        for (int i = 0; i < 5; i++)
        {
            if (Order[i] != Contents[i])
            {
                pass = false;
                if (Order[i] == false && Contents[i] == true)
                {
                    Debug.Log("fail");
                }
            }
        }
        if (pass)
        {
            if (FillChecker.GetComponent<Fillcheck>().Checkfill())
            {
                Debug.Log("pass");
                anim.SetTrigger("Rotate");
            }
        }
    }
}
