using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sfxSlider;

    public AudioSource sfxSource;

    void Start()
    {
        // Get the current volume
        float sfxVolume;
        mixer.GetFloat("SFXVolume", out sfxVolume);

        // Set the slider to the same value
        sfxSlider.value = sfxVolume;
    }

    void Update()
    {
        // Make the mixer match the slider value
        float sliderValue = sfxSlider.value;
        mixer.SetFloat("SFXVolume", sliderValue);
    }

    public void PlaySound()
    {
        // Play a sound effect
        sfxSource.Play();
    }
}
