using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretItem : MonoBehaviour
{
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject textPanel;
    [SerializeField] string[] monolog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        helpPanel.SetActive(true);
        if (Input.GetKey(KeyCode.F))
        {
            textPanel.SetActive(true);
        }
    }
}
