using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlant : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("Clap", true);
    }
}
