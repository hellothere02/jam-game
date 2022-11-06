using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrap : MonoBehaviour
{
    [SerializeField] private Animation animationDog;
    private bool isdeathWild = false;
    public static event OnDeathWild DeathWild;
    public delegate void OnDeathWild(bool death);
    [SerializeField] private AudioSource _sounDogWorld;

    private void Awake()
    {
        _sounDogWorld = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animationDog.Play();
        _sounDogWorld.Play();
    }
}
