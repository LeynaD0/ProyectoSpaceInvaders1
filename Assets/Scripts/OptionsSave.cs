using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSave : MonoBehaviour
{
    public AudioSource effectsSource;
    public AudioSource musicSource;

    public Slider sliderMusicSource;
    public Slider sliderEffectSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void MusicVolume()
    {
        musicSource.volume
    }
    
}
