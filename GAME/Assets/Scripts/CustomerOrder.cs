using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{
    public Canvas _Canvas;
    public GameObject playerRef;
    public List<string> CustomerText = new List<string>();
    public Camera _Camera;


    // Start is called before the first frame update
    void Start()
    {
        _Canvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        _Canvas.gameObject.SetActive(true);

        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
        _Camera.GetComponent<TextToScreen>().StartTalking(CustomerText);
    }

    private void OnTriggerExit(Collider other)
    {
        _Canvas.gameObject.SetActive(false);
    }
}
