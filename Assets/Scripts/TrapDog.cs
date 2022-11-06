using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDog : MonoBehaviour
{
    private bool isdeathWild = false;
    public static event OnDeathDog DeathDog;
    public delegate void OnDeathDog(bool death);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isdeathWild = true;
        DeathDog(isdeathWild);
    }
}