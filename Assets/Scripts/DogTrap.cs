using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrap : MonoBehaviour
{
    [SerializeField] private Animation animationDog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animationDog.Play();
    }
}
