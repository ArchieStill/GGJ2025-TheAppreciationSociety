using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Orderscheck : MonoBehaviour
{
    public GameObject IngredientChecker;
    public GameObject FillChecker;
    public Camera Camera;
    public TMP_Text response;
    public GameObject MIKU;

    private bool lookup = true;
    private float InactiveTime = 3.0f;

    void Update()
    {
        if (FillChecker.GetComponent<Fillcheck>().Checkfill())
        {
            MIKU.SetActive(true);
            InactiveTime -= Time.deltaTime;
            if (lookup)
            {
                Camera.GetComponent<Camera>().GetComponent<LookAtThe>().LookUp();
                lookup = false;
                response.SetText("Thank you!!!!");
            }
        }
        if (InactiveTime <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
