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
    private int currentIndexText;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            helpPanel.SetActive(false);
            textPanel.SetActive(true);
            currentText.text = monolog[currentIndexText];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        helpPanel.SetActive(true);

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
    }
}
