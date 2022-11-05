using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagenetUIGame : MonoBehaviour
{
    [SerializeField] private Image _screenOfDeath;
    private bool _ispocced;
    public static event OnProceed ProceedGame;
    public delegate void OnProceed(bool proceedGame);

    private bool _isclick = false;
    public static event OnClick Click;
    public delegate void OnClick(bool click);

   
    void OnEnable()
    {
        PlayerDeath.Death += ActivScreenOfDeath;
    }
    void OnDisable()
    {
        PlayerDeath.Death -= ActivScreenOfDeath;
    }
    private void ActivScreenOfDeath(bool activ)
    {
        if (activ)
            _screenOfDeath.gameObject.SetActive(true);
        _ispocced = false;
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        _isclick = true;
        Click(_isclick);
    }

    public void OnProceedGame()
    {
        _screenOfDeath.gameObject.SetActive(false);
        _ispocced = true;
        ProceedGame(_ispocced);
        _isclick = true;
        Click(_isclick);
    }
}
