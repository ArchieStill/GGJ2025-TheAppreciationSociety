using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrder : MonoBehaviour
{
    public Canvas _Canvas;
    public List<string> CustomerText = new List<string>();
    public Camera _Camera;


    void Start()
    {
        _Canvas.gameObject.SetActive(true);
        _Camera.GetComponent<TextToScreen>().StartTalking(CustomerText);
    }
}
