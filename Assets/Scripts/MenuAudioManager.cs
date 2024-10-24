using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource menuMusicSource;
    [SerializeField] public AudioSource SFXSource;
    
    public AudioClip menuMusic;
    public AudioClip clickSFX;
    
    private void Start()
    {
        menuMusicSource.clip = menuMusic;
        menuMusicSource.Play();
    }

    public void PlaySFX()
    {
        SFXSource.clip = clickSFX;
        SFXSource.Play();
    }
}
