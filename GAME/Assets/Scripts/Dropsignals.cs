using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropsignals : MonoBehaviour
{
    private Transform IconPosition;
    private string[] ingredients = {"Boba", "Jelly", "Tea", "Milk", "Syrup"};

    public void OnDrop(Transform DropPlace, string DropType)
    {
        Transform IconPosition = DropPlace;
        int ChildNumber = Array.IndexOf(ingredients, DropType);
        this.transform.GetChild(ChildNumber).transform.position = IconPosition.position;
    }
}
