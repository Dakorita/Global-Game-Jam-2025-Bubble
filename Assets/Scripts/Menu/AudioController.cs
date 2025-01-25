using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public bool musicMute;
    public bool soundMute;
    public AudioMixer audioMixer;
    public float previusSound = 0;
    public float previusMusic = 0;
    public void Start()
    {
        audioMixer = Resources.Load<AudioMixer>("MainMixed");
    }
    public float GetLevel(string bus)
    {
        float value;
        bool result = audioMixer.GetFloat(bus, out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }
    public void MasterVolume(Slider volumen)
    {
        audioMixer.SetFloat("Master", volumen.value);
    }
    public void MusicVolume(Slider volumen)
    {
        audioMixer.SetFloat("Musica", volumen.value); // los nombres que les pusimos al exponer el parametro
    }
    public void SoundVolume(Slider volumen)
    {
        audioMixer.SetFloat("Sonidos", volumen.value);
    }
    public void SoundMute()
    {
        if (soundMute)
        {
            soundMute = false;
            audioMixer.SetFloat("Sonidos", previusSound);
        }
        else
        {
            soundMute = true;
            previusSound = GetLevel("Sonidos");
            audioMixer.SetFloat("Sonidos", -80);
        }
    }
    public void MusicMute()
    {
        if (musicMute)
        {
            musicMute = false;
            audioMixer.SetFloat("Musica", previusMusic);
        }
        else
        {
            musicMute = true;
            previusMusic = GetLevel("Musica");
            audioMixer.SetFloat("Musica", -80);
        }
    }


}
