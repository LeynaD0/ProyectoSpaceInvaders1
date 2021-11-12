using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioControl: MonoBehaviour
{
    public static AudioControl instance;

    public AudioSource musicSource;
    public AudioSource effectsSource;
    public Slider sliderMusic;
    public Slider sliderEffects;

    public void Start()
    {
        instance = this;
       
        PlayerPrefs.SetFloat("volumenMusica", 0.5f);
        PlayerPrefs.SetFloat("volumenEfectos", 0.5f);
        MenuVolume();
    }

    private void MenuVolume()
    {
        musicSource.volume = PlayerPrefs.GetFloat("volumenMusica");
        effectsSource.volume = PlayerPrefs.GetFloat("volumenEfectos");
        
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
