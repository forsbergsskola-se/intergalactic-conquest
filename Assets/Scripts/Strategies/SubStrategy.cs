using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SubStrategy", menuName = "ScriptableObjects/Sub-Strategy", order = 0)]
public class SubStrategy : ScriptableObject, IStrategy
{
    [SerializeField] [Tooltip("The type that this strategy belongs to, will be used for save name prefixed by the planet")]
    private StrategyType strategyType;

    [Header("Params")] 
    [SerializeField] private float costBase = 1.15f;
    [Tooltip("The base cost")][SerializeField] float costCoefficient = 11f;

    private string savePrefix = "substrategy_";
    
    public int GetLevel(PlanetName planetName)
    {
        string saveName = savePrefix + planetName + Enum.GetName(typeof (StrategyType), strategyType);;
        Debug.Log(saveName);
        return PlayerPrefs.GetInt(saveName);
    }

    private void SetLevel(PlanetName planetName, int value)
    {
        string saveName = savePrefix + planetName + Enum.GetName(typeof (StrategyType), strategyType);
        PlayerPrefs.SetInt(saveName, value);
    }

    public void IncrementLevel(PlanetName planetName)
    {
        int currentLevel = GetLevel(planetName);
        SetLevel(planetName, currentLevel+1);
    }

    public float GetCost(PlanetName planetName)
    {
        return costCoefficient * Mathf.Pow(costBase, GetLevel(planetName));
    }
}