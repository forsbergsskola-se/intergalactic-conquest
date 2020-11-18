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
    [Header("Requirements")]
    [Tooltip("The base cost")][SerializeField] float costCoefficient = 500f;
    [Tooltip("The strategy that dictates if adequate level has been reached.")][SerializeField] public ScriptableObject reqStrategy; //References a scriptable object that holds the required type- current player level.
    private IStrategy reqStrategyRef; //derived at runtime from reqStrategy
    
    [Header("Effects")]
    [Tooltip("Multiplies the passive income for the substrategy by this ammount for each level")] 
    public BonusMultiplier Bonus = new BonusMultiplier(2.0f, StrategyType.DiplomatCommongrounder);

    [Header("Params")] [SerializeField] private float costBase = 1.3f;

    [Tooltip("Name used to save the state internally in PlayerPrefs")] [SerializeField]
    private string SaveName = "OverrideMe";

    public int GetLevel(PlanetName planetName)
    {
        string saveName = Enum.GetName(typeof(PlanetName), planetName) + SaveName;
        return PlayerPrefs.GetInt(saveName, 0);
    }
    
    public void SetLevel(PlanetName planetName, int val) {
        string saveName = Enum.GetName(typeof(PlanetName), planetName) + SaveName;
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
    

    [Serializable]
    public struct BonusMultiplier
    {
        public BonusMultiplier(float multiplier, StrategyType strategyType)
        {
            Multiplier = multiplier;
            StrategyType = strategyType;
        }

        public float Multiplier;
        public StrategyType StrategyType;
    }
}
