using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider slider;
    public AudioManager audioManager;

    private void Update()
    {
        audioManager.audioSource.volume = slider.value;
    }
}
