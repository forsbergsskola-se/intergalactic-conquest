using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent (typeof(Slider))]
public class MenuSettings : MonoBehaviour
{
    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    
    [SerializeField] private string volumeName;
    [SerializeField] public Text volumeLabel;

    private void Start()
    {
        ResetSliderValue();
        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    public void UpdateValueOnChange(float value)
    {
        if (volumeLabel != null)
        {
            volumeLabel.text = Mathf.Round(value * 100.0f).ToString() + "%";
        }

        if (Settings.profile)
        {
            Settings.profile.SetAudioLevels(volumeName, value);
        }
    }

    public void ResetSliderValue()
    {
        if (Settings.profile)
        {
            float volume = Settings.profile.GetAudioLevels(volumeName);
            UpdateValueOnChange(volume);
            slider.value = volume;
        }
    }
}
