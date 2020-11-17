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
    [Header("References")] 
    //[Tooltip("The strategy type for this upgrade")]
    //public Strategy Strategy; //References a scriptable object that holds current player level for this Upgrade.

    [Tooltip("The spendable influence scriptable object")]
    [SerializeField] private Influence influence; //TODO consider other solutions if time allows.
    
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

    public int Level
    {
        get => PlayerPrefs.GetInt(SaveName, 0);
        private set => PlayerPrefs.SetInt(SaveName, value);
    }
    
    private void Awake()
    {
        if (reqStrategy == null)
            Debug.LogWarning("Please provide Strategy for required strategy level", this);
        reqStrategyRef = reqStrategy as IStrategy;
        
    }

    public bool CanBuy
    {
        get
        {
            if (reqStrategyRef == null)
                reqStrategyRef = reqStrategy as IStrategy;
            
            // can afford AND current level is at least the required level. 
            return CurrentCost <= this.influence.CurrentInfluence &&
                   reqStrategyRef.Level >= CurrentLevelRequirement;
        }
    }
    public float CurrentCost => costCoefficient * Mathf.Pow(costBase, Level);

    public int CurrentLevelRequirement
    {
        get
        {
            if (Level == 0)
                return 10;
            else
            {
                return Level * 50;
            }
        }
    }

    public bool PurchaseUpgrade()
    {
        // Requirements not met
        if (!CanBuy)
            return false;
        
        // Make transaction
        this.influence.CurrentInfluence -= CurrentCost;
        this.Level += 1;
        return true;
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
