using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet", order = 1)]
public class Planet : ScriptableObject
{
    [Header("Planet Data")] public Sprite PlanetSprite;

    [Header("Planet Settings")] [SerializeField]
    private PlanetBonusList planetBonusList;

    public ProductionState State = ProductionState.Inactive;
    public PlanetName PlanetName;
    public float StartingInfluence = 10000f;

    [Header(" Planet Staff & Upgrades")] 
    public Staff Staff;
    // [SerializeField] private StaffList StaffList;

    [Space] [SerializeField] private UpgradeList UpgradeList;

    [Header("Domination")] public float InfluenceGoal;

    // Derived variables
    //private Dictionary<StrategyType, Bonus> bonusLookupTable; //Generated at runtime, unique for each planet. Derived from planetBonusList
    private string spendableInfluenceSaveName;
    private string totalInfluenceSaveName;

    //Properties
    public float SpendableInfluence
    {
        get => PlayerPrefs.GetFloat(spendableInfluenceSaveName, StartingInfluence);
        private set
        {
            PlayerPrefs.SetFloat(spendableInfluenceSaveName, value);
            OnInfluenceChange.Invoke();
        }
    }

    public float TotalInfluence
    {
        get => PlayerPrefs.GetFloat(totalInfluenceSaveName);
        private set => PlayerPrefs.SetFloat(totalInfluenceSaveName, value);
    }

    [HideInInspector] public UnityEvent OnInfluenceChange;

    public void IncreaseInfluence(float amount)
    {

        SpendableInfluence += amount;
        TotalInfluence += amount;
    }

    public void DecreaseInfluence(float amount)
    {

        SpendableInfluence -= amount;
    }

    private void Awake()
    {
        string planetName = Enum.GetName(typeof(PlanetName), this.PlanetName);
        this.spendableInfluenceSaveName = "influence_" + planetName;
        this.totalInfluenceSaveName = "influence_" + planetName;
    }

    public float GetPlanetBonusMultiplier(StrategyType strategyType)
    {
        return planetBonusList.GetBonusMultiplier(strategyType);
    }

    public float GetStrategyBonusMultiplier(StrategyType strategyType)
    {
        //get the upgrade
        var upgrade = UpgradeList.GetUpgrade(strategyType);
        
        // get the value from the upgrade for this planet
        int level = upgrade.GetLevel(this.PlanetName);
        float upgradeBonusMultiplier = upgrade.BonusMultiplier;
        
        // level can be 0 therefore setting min value to 1
        return Mathf.Max( 1.0f, level * upgradeBonusMultiplier);
    }
}


public enum ProductionState
{
    Active,
    Inactive
}