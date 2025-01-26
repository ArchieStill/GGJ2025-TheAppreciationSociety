using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fillcheck : MonoBehaviour
{
    private bool Filled;

    public bool Checkfill()
    {
        Filled = true;
        for (int i = 0; i < 5; i++)
        {
            if (!this.transform.GetChild(i).gameObject.GetComponent<Levelcheck>().FillStatus())
            {
                Filled = false;
            }
        }
        return Filled;
    }
}
