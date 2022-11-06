using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagementMainMenu : MonoBehaviour
{
    private bool _isclick = false;
    public static event OnClick Click;
    public delegate void OnClick(bool click);
    [SerializeField] private Image _raz;

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
    public void RazInfo()
    {
        _raz.gameObject.SetActive(true);
        Click(_isclick);
    }

    public void StartMenu()
    {
        _raz.gameObject.SetActive(false);
        Click(_isclick);
    }
}
