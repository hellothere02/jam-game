using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagementMainMenu : MonoBehaviour
{
    public void StarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }   
}
