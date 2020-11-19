using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class AudioChanger : MonoBehaviour
{
    public AudioSource audiosource;

    public void Awake()
    {
        if (PlanetManager.instance.OnPlanet())
        {
            ChangesMusic(PlanetManager.instance.CurrentPlanet); 
            audiosource.Play();
        }
    }

    public void ChangesMusic(Planet planet)
    {
        audiosource.clip = planet.music;
    }
}
