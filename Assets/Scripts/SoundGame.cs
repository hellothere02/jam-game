using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGame : MonoBehaviour
{
    [SerializeField] private AudioSource _soundClickOnButton;
    [SerializeField] private AudioSource _sounDeathPlayer;
    [SerializeField] private AudioSource _sounStepPlayer;
    [SerializeField] private AudioSource _sounJumpPlayer;
    [SerializeField] private AudioSource _sounAlightingdPlayer;
    [SerializeField] private AudioSource _sounPlantWorld;

    void OnEnable()
    {
        ManagementMainMenu.Click += SoundCliclPlay;
        ManagenetUIGame.Click += SoundCliclPlay;
        //PlayerDeath.SoundDeath+= SoundDeathPlay;
        PlayerMovement.Step += SoundStepPlay;
        PlayerMovement.JumpSound += SoundJumpPlayer;
        PlayerMovement.Alightingd += SoundAlightingdPlayer;
        WildPlant.DeathWild += SoundPlantWorld;
    }
    void OnDisable()
    {
        ManagementMainMenu.Click -= SoundCliclPlay;
        ManagenetUIGame.Click -= SoundCliclPlay;
        //PlayerDeath.SoundDeath -= SoundDeathPlay;
        PlayerMovement.Step -= SoundStepPlay;
        PlayerMovement.JumpSound -= SoundJumpPlayer;
        PlayerMovement.Alightingd -= SoundAlightingdPlayer;
        WildPlant.DeathWild -= SoundPlantWorld;
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
    private void SoundStepPlay(bool activ)
    {
        if (activ)
        {
            _sounStepPlayer.Play();
        }
    }
    private void SoundJumpPlayer(bool activ)
    {
        if (activ)
        {
            _sounJumpPlayer.Play();
        }
    }
    private void SoundAlightingdPlayer(bool activ)
    {
        if (activ)
        {
            _sounAlightingdPlayer.Play();
        }
    }
    private void SoundPlantWorld(bool activ)
    {
        if (activ)
        {
            _sounPlantWorld.Play();
        }
    }
}
