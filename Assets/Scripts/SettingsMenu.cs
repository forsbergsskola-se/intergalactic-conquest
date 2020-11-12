using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent (typeof(Slider))]
public class SettingsMenu : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    public AudioMixer audioMixer;
    [SerializeField] private string volumeName;
    [SerializeField] public Text volumeLabel;

    private void Start()
    {
        SetVolume(slider.value);
        slider.onValueChanged.AddListener(delegate
        {
            SetVolume(slider.value);
        });
    }
    public void SetVolume(float value)
    {
        if (audioMixer != null)
        audioMixer.SetFloat(volumeName, Mathf.Log(value) * 20f);

        if (volumeLabel != null)
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
    }
}
