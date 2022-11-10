using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPlant : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private BoxCollider2D boxCollider2;
    private bool isdeathWild = false;
    public static event OnDeathWild DeathWild;
    public delegate void OnDeathWild(bool death);

    private void Start()
    {
        boxCollider2 = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        boxCollider2.enabled = false;
        anim.SetBool("Clap", true);
        isdeathWild = true;
        DeathWild(isdeathWild);
    }
}
