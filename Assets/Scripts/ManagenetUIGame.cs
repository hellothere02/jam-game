using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagenetUIGame : MonoBehaviour
{
    [SerializeField] private Image _screenOfDeath;
    private bool _ispocced;
    public static event OnProceed ProceedGame;
    public delegate void OnProceed(bool proceedGame);

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
    }

    public void OnProceedGame()
    {
        _screenOfDeath.gameObject.SetActive(false);
        _ispocced = true;
        ProceedGame(_ispocced);
    }
}