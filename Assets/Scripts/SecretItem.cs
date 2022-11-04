using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretItem : MonoBehaviour
{
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject textPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        helpPanel.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.F))
        {
            textPanel.SetActive(true);
        }
    }
}
