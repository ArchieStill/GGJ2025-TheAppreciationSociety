using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orderscheck : MonoBehaviour
{
    public GameObject IngredientChecker;
    private bool[] Contents = new bool[5];
    private bool[] Order = new bool[5];

    void Start()
    {
        SetOrder();
    }

    void SetOrder()
    {
        Order[0] = true;
        Order[1] = true;
        Order[2] = false;
        Order[3] = false;
        Order[4] = false;
    }

    void Update()
    {
        Contents = IngredientChecker.GetComponent<IngredientCheck>().ReturnContents();
        bool pass = true;
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(Contents[0]);
            if (Order[i] != Contents[i])
            {
                pass = false;
            }
        }
        if (pass)
        {
            Debug.Log("pass");
        }
    }
}
