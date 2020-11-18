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
    public Text LevelText;

    // variables
    private Planet planet = null;
    
    public void ButtonClick()
    {
        TryToBuyUpgrade();
    }

    private void Awake()
    {
        planet = PlanetManager.instance.CurrentPlanet;
        if (planet == null)
        {
            Debug.LogWarning("Planet not found", this);
        }
    }

    public void Start()
    {
        if (this.Strategy == null)
        {
            Debug.LogWarning("Necessary components not found", this);
            SetText("80085");
        }
        else 
            UpdateText();
    }

    private void TryToBuyUpgrade()
    {
        PlanetName planetName = planet.PlanetName;
        float cost = this.Strategy.GetCost(planetName);
        
        //not enough influence
        if (cost > RetrieveInfluence())
            return;
        
        //make transaction
        this.planet.DecreaseInfluence(cost);
        this.Strategy.IncrementLevel(planetName);
        UpdateText();
    }
    
    private float RetrieveInfluence()
    {
        if (planet == null)
        {
            this.planet = PlanetManager.instance.CurrentPlanet;
            if (planet == null)
                Debug.LogWarning("Planet not found", this);
        }

        return planet.SpendableInfluence;
    }
    
    private void UpdateText()
    {
        SetText(Strategy.GetLevel(planet.PlanetName).ToString());
    }

    private void SetText(String s)
    {
        this.LevelText.text = s;
    }
    
}
