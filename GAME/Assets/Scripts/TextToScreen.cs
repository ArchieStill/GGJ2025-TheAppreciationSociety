using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextToScreen : MonoBehaviour
{
    public TMP_Text textMeshPro;
    
    private List<string> CustomerText = new List<string>();
    int pointer = 0;

    void Start()
    {
        //If you wanted to append to the top of the list
        CustomerText.Add("Customer: Hey can I get a caramel macchiato");
        CustomerText.Add("Customer: You dont sell that? Oh");
        CustomerText.Add("Customer: Just a default boba then I guess");

        textMeshPro.SetText(CustomerText[pointer].ToString());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("he");
            if (pointer + 1 != CustomerText.Count)
            {
                pointer += 1;
                textMeshPro.SetText(CustomerText[pointer].ToString());
            }
        }
    }
}
