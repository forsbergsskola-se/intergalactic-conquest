using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/*
 * The class related to Economy Military and Diplomat upgrades on the planet
 * Current requirement for the upgrades include:
 * lvl, cost, level requirements for purchase, overall influence yield multiplier, branch yield multiplier, and maybe click yield multiplier
 */


[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade", order = 4)]
public class Upgrade : ScriptableObject
{

    [FormerlySerializedAs("strategyType")]
    [Header("UpgradeType")] [Tooltip("The type of this upgrade. Used for save name prefixed with the planet name")]
    [SerializeField] public StrategyType StrategyType;

    [Header("Requirements")]
    [Tooltip("The strategy that dictates if adequate level has been reached.")][SerializeField] public ScriptableObject reqStrategy; //References a scriptable object that holds the required type- current player level.
    private IStrategy reqStrategyRef; //derived at runtime from reqStrategy
    
    [Header("Effects")]
    [Tooltip("Multiplies the passive income for the substrategy by this ammount for each level")] 
    public float BonusMultiplier = 2.0f;

    [Header("Params")] 
    [SerializeField] private float costBase = 1.3f;
    [Tooltip("The base cost")][SerializeField] float costCoefficient = 500f;
    
    private string savePrefix = "upgrade_";

    public int GetLevel(PlanetName planetName)
    {
        // eg. saving in playerPrefs as upgrade_EarthDiplomacyCommongrounder
        string saveName = savePrefix + Enum.GetName(typeof(PlanetName), planetName) + Enum.GetName(typeof(StrategyType), StrategyType);
        return PlayerPrefs.GetInt(saveName, 0);
    }
    
    public void SetLevel(PlanetName planetName, int val) {
        // eg. fetching upgrade_EarthDiplomacyCommongrounder in PlayerPrefs
        string saveName = savePrefix + Enum.GetName(typeof(PlanetName), planetName) + Enum.GetName(typeof(StrategyType), StrategyType);
        PlayerPrefs.SetInt(saveName, val);
    }

    public void IncrementLevel(PlanetName planetName)
    {
        int currentLevel = GetLevel(planetName);
        SetLevel(planetName, currentLevel+1);
    }
    
    private void Awake()
    {
        if (reqStrategy == null)
            Debug.LogWarning("Please provide Strategy for required strategy level", this);
        reqStrategyRef = reqStrategy as IStrategy;
        
    }

    public bool CanBuy(Planet planet)
    {
        PlanetName planetName = planet.PlanetName;
        
        if (reqStrategyRef == null)
            reqStrategyRef = reqStrategy as IStrategy;

        return GetCurrentCost(planetName) <= RetrieveInfluence(planet) && 
               reqStrategyRef.GetLevel(planetName) >= GetCurrentLevelRequirement(planetName);
    }

    public float GetCurrentCost(PlanetName planetName)
    {
        return costCoefficient * Mathf.Pow(costBase, GetLevel(planetName));
    }

    public int GetCurrentLevelRequirement(PlanetName planetName)
    {
        int level = GetLevel(planetName);
        if (level == 0)
        {
            return 10;
        }
        else
        {
            return level * 50;
        }
    }

    public bool PurchaseUpgrade(Planet planet)
    {
        PlanetName planetName = planet.PlanetName;
        
        // Requirements not met
        if (!CanBuy(planet))
            return false;
        
        //Make transaction
        planet.DecreaseInfluence(GetCurrentCost(planetName));
        IncrementLevel(planetName);
        return true;
    }

    private float RetrieveInfluence(Planet planet)
    {
        return planet.SpendableInfluence;
    }

    private void SpendInfluence(Planet planet, float amount)
    {
        planet.DecreaseInfluence(amount);
    }
}
