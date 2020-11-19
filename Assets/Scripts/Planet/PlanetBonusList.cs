using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlanetBonusList", order = 10)]
public class PlanetBonusList : ScriptableObject
{
    [Tooltip("The 9 strat related bonuses that each planet will have")][SerializeField] private PlanetBonus[] bonusList;
    
    private Dictionary<StrategyType, float> bonusLookupTable;
    
    private void GenerateLookupTable()
    {
        bonusLookupTable = new Dictionary<StrategyType, float>();
        foreach (var pb in bonusList)
        {
            bonusLookupTable.Add(pb.StrategyType, pb.Multiplier);
        }
    }

    private void OnEnable()
    {
        GenerateLookupTable();
    }
        
    public float GetBonusMultiplier(StrategyType strategyType)
    {
        /*
        if(upgradeLookupTable == null)
            GenerateLookupTable();
        */
        
        float b;
        if (!bonusLookupTable.TryGetValue(strategyType, out b)) 
            Debug.LogError("upgrade not found in list", this);
        
        return b;
    }

    [Serializable]
    public struct PlanetBonus
    {
        public StrategyType StrategyType;
        [Tooltip("multiplier, i.e. 1.01 is 1% increase and 2 is *2 increase.") ]public float Multiplier;
    }

}
