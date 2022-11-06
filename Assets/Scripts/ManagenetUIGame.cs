using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagenetUIGame : MonoBehaviour
{
    [SerializeField] private Image _screenOfDeath;
    [SerializeField] private Image _ecpMenu;
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    private bool _ispocced;
    public static event OnProceed ProceedGame;
    public delegate void OnProceed(bool proceedGame);

    private bool _isclick = false;
    public static event OnClick Click;
    public delegate void OnClick(bool click);

    private bool _isEsp = false;


    void OnEnable()
    {
        PlayerDeath.Death += ActivScreenOfDeath;
    }
    void OnDisable()
    {
        PlayerDeath.Death -= ActivScreenOfDeath;
    }
    private void Update()
    {
        Menu();
        _audio.volume = _slider.value;
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

    private void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isEsp == false)
        {
            _ecpMenu.gameObject.SetActive(true);
            _isEsp = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isEsp == true)
        {
            _ecpMenu.gameObject.SetActive(false);
           _isEsp = false;
        }
    }

    public void GetScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
