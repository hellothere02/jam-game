using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagementMainMenu : MonoBehaviour
{
    public void StarGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }   
}
