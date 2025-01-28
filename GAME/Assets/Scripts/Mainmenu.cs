
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
        Application.Quit();
    }

    //begins the gameplay when start button is pressed
    public void Begin()
    {
        SceneManager.LoadScene(1);
    }
}
