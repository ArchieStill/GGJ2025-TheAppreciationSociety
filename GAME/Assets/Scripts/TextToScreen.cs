using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextToScreen : MonoBehaviour
{
    public TMP_Text textMeshPro;
    int pointer = 0;

    private List<string> currentConversation;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentConversation != null)
            {
                if (pointer + 1 != currentConversation.Count)
                {
                    pointer += 1;
                    textMeshPro.SetText(currentConversation[pointer].ToString());
                }
            }
        }
    }

    public void StartTalking(List<string> text)
    {
        pointer = 0;
        currentConversation = text;

        textMeshPro.SetText(text[pointer].ToString());
    }
}
