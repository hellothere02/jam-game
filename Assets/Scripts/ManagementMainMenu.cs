using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagementMainMenu : MonoBehaviour
{
    private bool _isclick = false;
    public static event OnClick Click;
    public delegate void OnClick(bool click);

    public void StarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        _isclick = true;
        Click(_isclick);
    }

    public void ExitGame()
    {
        Application.Quit();
        _isclick = true;
        Click(_isclick);
    }   
}
