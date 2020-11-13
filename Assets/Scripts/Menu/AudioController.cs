using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private SoundSettings s_profiles;
    [SerializeField] private List <MenuSettings> s_VolumeSliders = new List<MenuSettings>();

//very weird but works
    private void Awake () {
        if (s_profiles != null)
            s_profiles.SetProfile(s_profiles);
    }

    public void Start()
    {
        if(Settings.profile && Settings.profile.audioMixer !=null)
            Settings.profile.GetAudioLevels();
    }
    
    public void ApplyChanges()
    {
        if(Settings.profile && Settings.profile.audioMixer !=null)
            Settings.profile.SaveAudioLevels();
    }

    public void CancelChanges()
    {
        if(Settings.profile && Settings.profile.audioMixer !=null)
            Settings.profile.GetAudioLevels();
        for (int i = 0; i < s_VolumeSliders.Count; i++)
        {
            s_VolumeSliders[i].ResetSliderValue();
        }
    }
}

