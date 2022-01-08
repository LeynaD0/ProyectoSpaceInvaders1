using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioControl: MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource effectsSource;
    public Slider sliderMusic;
    public Slider sliderEffects;
    public float valor; 

    public void Start()
    {
        sliderMusic.value = 0.5f;
        sliderEffects.value = 0.5f;
    }
    public void CancelButton()
    {
        PlayerPrefs.GetFloat("volumenMusica");
        PlayerPrefs.GetFloat("volumenEfectos"); 
    }
    public void AcceptButton()
    {
        PlayerPrefs.SetFloat("volumenMusica", sliderMusic.value);
        PlayerPrefs.SetFloat("volumenEfectos", sliderEffects.value);
    }

    public void SliderMusicModified()
    {
        musicSource.volume = sliderMusic.value;
        
    }

    public void SliderEffectsModified()
    {
        effectsSource.volume = sliderEffects.value;
    }
}
