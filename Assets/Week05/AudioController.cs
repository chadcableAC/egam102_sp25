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
        float sfxVolume;
        mixer.GetFloat("SFXVolume", out sfxVolume);

        sfxSlider.value = sfxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void PlaySound()
    {
        sfxSource.Play();
    }
}
