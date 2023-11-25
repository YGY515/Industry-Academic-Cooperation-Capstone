using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlide : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float sound = audioSlider.value;

        if (sound == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", sound);
    }

}
