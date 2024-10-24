using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource gameMusicSource;
    [SerializeField] public AudioSource SFXSource;

    public AudioClip gameMusic;
    public AudioClip clickSFX;

    private void Start()
    {
        gameMusicSource.clip = gameMusic;
        gameMusicSource.Play();
    }

    public void PlaySFX()
    {
        SFXSource.clip = clickSFX;
        SFXSource.Play();
    }
}