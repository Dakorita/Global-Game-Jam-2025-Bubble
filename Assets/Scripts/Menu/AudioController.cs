using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public bool masterMute;
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
    public void MasterMute()
    {
        if (masterMute)
        {
            masterMute = false;
            audioMixer.SetFloat("Master", previusSound);
        }
        else
        {
            masterMute = true;
            previusSound = GetLevel("Master");
            audioMixer.SetFloat("Master", -80);
        }
    }



}
