using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    //closes the game when exit button is pressed
    public void Exit()
    {
        Debug.Log("quitting game");
        Application.Quit();
    }

    //begins the gameplay when start button is pressed
    public void Begin()
    {
        Debug.Log("Startgame");
        SceneManager.LoadScene(2);
    }
}
