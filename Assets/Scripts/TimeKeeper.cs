using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// On game quit: Detects when the game is shut down and stores the current time.
/// On game start: the time span between now and the last shut down is computed.
/// TODO: use the computed time span to retroactively generate passive income.
/// </summary>
public class TimeKeeper : MonoBehaviour
{
    private const string TimeSaveName = "last_shut_down_time";
    private DateTime tempCurrentTime;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Timekeeper");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //The first time the game is played, no stored key exist yet.
        if (!PlayerPrefs.HasKey(TimeSaveName)) 
            return;
        
        // Fetch the time that was stored the last time the game was shut down.
        string storedString = PlayerPrefs.GetString(TimeSaveName);
        
        // Parse the string and guard for errors
        DateTime lastShutDownTime;
        if (!DateTime.TryParse(storedString, out lastShutDownTime))
        {
            Debug.Log("Some error was encountered, setting last shut down time to current time");
            lastShutDownTime = DateTime.Now;
        }
        
        this.tempCurrentTime = lastShutDownTime;
        Debug.Log($"Start time: {lastShutDownTime}");
        TimeSpan totalTimeSinceLastShutDown = DateTime.Now - lastShutDownTime;
        Debug.Log($"Time since last shutdown: {totalTimeSinceLastShutDown}");

        GeneratePassiveIncomeRetroactively(totalTimeSinceLastShutDown);
    }

    
    private void GeneratePassiveIncomeRetroactively(TimeSpan t)
    {
        //TODO
        Debug.Log($"Should generate passive income for {t.TotalSeconds} Seconds. Please implement");
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan interval = DateTime.Now - this.tempCurrentTime;
        Debug.Log($"Total time since start: {interval}");
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        StoreCurrentTime();
    }

    private void OnApplicationQuit()
    {
        StoreCurrentTime();
    }

    private void StoreCurrentTime()
    {
        DateTime currentTime = DateTime.Now;
        string timeString = currentTime.ToString();
        PlayerPrefs.SetString(TimeSaveName, timeString);
    }
}
