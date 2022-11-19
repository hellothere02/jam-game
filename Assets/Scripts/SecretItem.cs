using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SecretItem : MonoBehaviour
{
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI currentText;
    [SerializeField] private string[] monolog;
    [SerializeField] private ManagenetUIGame managenetUI;
    [SerializeField] private AudioMixerGroup _audioMixerGame;
    private AudioSource _audioMixerPossitiv;
    [SerializeField] private Slider _slider;
    //private AudioMixerGroup _audioMixerNegativ;
    private int currentIndexText;
    private bool isAllow;
    private int _pickUpMemory;

    public static event OnPickUpMemory PickUpMemory;
    public delegate void OnPickUpMemory(int memory);

    private void Awake()
    {
       // _audioMixerShere.audioMixer.SetFloat("MasterMemorydParam", -80);
       ///_audioMixerNegativ = GetComponent<AudioMixerGroup>();
       _audioMixerPossitiv = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && isAllow)
        {
            //managenetUI.GetScore();
            _audioMixerGame.audioMixer.SetFloat("MasterGameParam", -80);
            _audioMixerPossitiv.Play();
            _audioMixerPossitiv.volume = _slider.value;
            helpPanel.SetActive(false);
            textPanel.SetActive(true);
            currentText.text = monolog[currentIndexText];
            //_audioMixerGame.audioMixer.SetFloat("MasterGameParam", -80);
            //_audioMixerPossitiv.volume = 1;
         
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        helpPanel.SetActive(true);
        isAllow = true;
    }

    public void NextMessege()
    {
        if (currentIndexText < monolog.Length - 1)
        {
            currentIndexText++;
            currentText.text = monolog[currentIndexText];
        }
    }

    public void LastMessege()
    {
        if (currentIndexText > 0)
        {
            currentIndexText--;
            currentText.text = monolog[currentIndexText];
        }
    }

    public void ClosePopUp()
    {
        textPanel.SetActive(false);
        _pickUpMemory++;           
        PickUpMemory(_pickUpMemory);
        Destroy(gameObject);
        _audioMixerGame.audioMixer.SetFloat("MasterGameParam", 0);
        _audioMixerPossitiv.Stop();
    }
}
