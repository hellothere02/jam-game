using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SecretItem : MonoBehaviour
{
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI currentText;
    [SerializeField] private string[] monolog;
    [SerializeField] private AudioSource _World;
    [SerializeField] private AudioSource _mysourse;
    [SerializeField] private Slider _slider;
    private int currentIndexText;
    private bool isAllow;
    private void Awake()
    {
        _mysourse = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && isAllow)
        {
            helpPanel.SetActive(false);
            textPanel.SetActive(true);
            currentText.text = monolog[currentIndexText];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        helpPanel.SetActive(true);
        _mysourse.Play();
        _World.Stop();
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
        _mysourse.Stop();
        _World.Play();
        Destroy(gameObject);
    }
}
