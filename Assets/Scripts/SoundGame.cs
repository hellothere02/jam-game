using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGame : MonoBehaviour
{
    [SerializeField] private AudioSource _soundClickOnButton;
    [SerializeField] private AudioSource _sounDeathPlayer;

    void OnEnable()
    {
        ManagementMainMenu.Click += SoundCliclPlay;
        ManagenetUIGame.Click += SoundCliclPlay;
        PlayerDeath.SoundDeath += SoundDeathPlay;
    }
    void OnDisable()
    {
        ManagementMainMenu.Click -= SoundCliclPlay;
        ManagenetUIGame.Click -= SoundCliclPlay;
        PlayerDeath.SoundDeath -= SoundDeathPlay;
    }

    private void SoundCliclPlay(bool activ)
    {
        if (activ)
        { 
                _soundClickOnButton.Play();
        }
    }
    private void SoundDeathPlay(bool activ)
    {
        if (activ)
        {
            _sounDeathPlayer.Play();
        }
    }

}
