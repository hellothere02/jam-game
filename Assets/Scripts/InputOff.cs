using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOff : MonoBehaviour
{
    [SerializeField] private GameObject sherli;
    private GameObject player;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        player.GetComponentInParent<PlayerInput>().enabled = false;
        player.GetComponentInParent<Animator>().SetFloat("Velocity", 0);
        sherli.GetComponent<Animator>().SetBool("Run", true);
    }

    public void ReduceInput()
    {
        player.GetComponentInParent<PlayerInput>().enabled = true;
        Destroy(gameObject);
    }
}
