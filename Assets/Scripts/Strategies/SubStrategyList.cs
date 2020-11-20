using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds a list for all strategies that should be reset when a planet is reset
/// </summary>
[CreateAssetMenu(fileName = "SubStrategyList", menuName = "ScriptableObjects/SubStrategyList", order = 11)]
public class SubStrategyList : ScriptableObject
{
    [Tooltip("Provide all substrategies that should reset when a planet is reset")] 
    public SubStrategy[] SubStrategyArray;

    public void ResetSubStrategies(PlanetName planetName)
    {
        foreach (var subStrategy in SubStrategyArray)
        {
            subStrategy.ResetSubStrategy(planetName);
        }
    }
}