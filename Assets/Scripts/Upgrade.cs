using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * The class related to Economy Military and Diplomat upgrades on the planet
 * Current requirement for the upgrades include:
 * lvl, cost, level requirements for purchase, overall influence yield multiplier, branch yield multiplier, and maybe click yield multiplier
 */



[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObjects/Upgrade", order = 4)]
public class Upgrade : ScriptableObject
{
    [Header("Strategy Type")] 
    public Strategy Strategy; //References a scriptable object that holds current player level.
    
    [Header("Requirements")]
    public float InfluenceCost = 100f;
    [Tooltip("Level requirements for this upgrade")]
    public StratLvlReq[] LevelRequirementArr;
    
    [Header("Effects")]
    [Tooltip("Multiplies the passive income for the substrategy")] 
    public float SubstrategyMultiplier = 1.0f;
    [SerializeField] [Tooltip("Multiplies the passive income for the main strategy")]
    public float MainStrategyMultiplier = 1.0f;
    [SerializeField] [Tooltip("Multiplies the click income")]
    public float ClickMultiplier = 1.0f;
    //TODO staff effiency? Was in the GDD, don't know what it means.


    [Serializable]
    public struct StratLvlReq
    {
        public StrategyType Strategy;
        public int Level;
    }
}
