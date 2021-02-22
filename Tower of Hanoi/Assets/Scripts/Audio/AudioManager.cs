using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource sfxPlayer;

    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer sfxMixer;

    [SerializeField] private AudioClip pressButtonSFX;
    [SerializeField] private AudioClip winSFX;

    [SerializeField] private AudioClip backgroundMusic;

    [SerializeField] private float minimalVolume;

    private void Awake() 
    {
        if (!musicPlayer) musicPlayer = transform.Find("Music Player").GetComponent<AudioSource>();
        if (!sfxPlayer) sfxPlayer = transform.Find("SFX Player").GetComponent<AudioSource>();
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("MusicVolume", volume);

        if (volume <= minimalVolume) musicMixer.SetFloat("MusicVolume", -80f);
    }

    public void SetSFXVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", volume);

        if (volume <= minimalVolume) sfxMixer.SetFloat("SFXVolume", -80f);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxPlayer.PlayOneShot(clip);
    }
}
