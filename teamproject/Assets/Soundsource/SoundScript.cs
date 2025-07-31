using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider BgmSlider;
    [SerializeField] private Slider SESlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        audioMixer.GetFloat("BGM", out float BGMVolume);
        BgmSlider.value = BGMVolume;
        audioMixer.GetFloat("SE",out float SESVolume);
        SESlider.value = SESVolume;
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
}
