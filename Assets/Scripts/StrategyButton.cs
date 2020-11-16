using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrategyButton : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The strategy associated with this button")]
    public SubStrategy Strategy;
    //Reference to a dummy class for the influence
    public Influence Influence;
    public Text LevelText;

    public void ButtonClick()
    {
        TryToBuyUpgrade();
    }

    public void Start()
    {
        if (this.Influence == null || this.Strategy == null)
        {
            Debug.LogWarning("Necessary components not found", this);
            SetText("80085");
        }
        else 
            UpdateText();
    }

    private void TryToBuyUpgrade()
    {
        //not enough influence
        if (this.Strategy.Cost >= this.Influence.CurrentInfluence)
            return;
        
        //make transaction
        this.Influence.CurrentInfluence -= Strategy.Cost;
        this.Strategy.Level += 1;
        UpdateText();
        Debug.Log("current influence : " + this.Influence.CurrentInfluence); //TODO remove log!
        //TODO update influence
    }
    
    private void UpdateText()
    {
        SetText(Strategy.Level.ToString());
    }

    private void SetText(String s)
    {
        this.LevelText.text = s;
    }
    
}
