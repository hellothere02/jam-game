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

    static public ManagenetUIGame instance;
    public bool isDeath;
    private bool _ispocced;
    public static event OnProceed ProceedGame;
    public delegate void OnProceed(bool proceedGame);
    private int _amount;
    private bool _isclick = false;
    public static event OnClick Click;
    public delegate void OnClick(bool click);

    private bool _isEsp = false;

    private void Awake()
    {
        instance = GetComponent<ManagenetUIGame>();
    }
    void OnEnable()
    {
        PlayerDeath.Death += ActivScreenOfDeath;
        SecretItem.PickUpMemory += GetScore;
    }
    void OnDisable()
    {
        PlayerDeath.Death -= ActivScreenOfDeath;
        SecretItem.PickUpMemory -= GetScore;
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
        Time.timeScale = 0;
        isDeath = true;
    }

    public void OnMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return;
        SceneManager.LoadScene("MainMenu");
        _isclick = true;
        Click(_isclick);
    }

    public void OnProceedGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return;
        _screenOfDeath.gameObject.SetActive(false);
        Time.timeScale = 1;
        _ispocced = true;
        ProceedGame(_ispocced);
        _isclick = true;
        Click(_isclick);
        isDeath = false;
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

    public void GetScore(int score)
    {
        _amount += score;
        scoreText.text = _amount.ToString();
    }
}
