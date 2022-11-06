using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlant : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool isdeathWild = false;
    public static event OnDeathWild DeathWild;
    public delegate void OnDeathWild(bool death);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("Clap", true);
        isdeathWild = true;
        DeathWild(isdeathWild);
    }
}
