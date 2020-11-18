using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet", order = 1)]
public class Planet : ScriptableObject
{
    [Header("Planet Data")]
    public Sprite PlanetSprite;
    
    [Header("Planet Settings")]
    public ProductionState State = ProductionState.Inactive;
    public PlanetName PlanetName;
    public float StartingInfluence = 10000f;
    
    [Header(" Planet Staff & Upgrades")]
    public Staff Staff;

    [Space]
    public Upgrade[] Upgrades;

    [Header("Domination")]
    public float InfluenceGoal;

    // Derived variables
    private string spendableInfluenceSaveName;

    private string totalInfluenceSaveName;
    
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

    [HideInInspector]
    public UnityEvent OnInfluenceChange;

    public void IncreaseInfluence(float amount){

        SpendableInfluence += amount;
        TotalInfluence += amount;
    }

    public void DecreaseInfluence(float amount){

        SpendableInfluence -= amount;
    }

    private void Awake()
    {
        string planetName = Enum.GetName(typeof(PlanetName), this.PlanetName);
        this.spendableInfluenceSaveName = "influence_" + planetName;
        this.totalInfluenceSaveName = "influence_" + planetName;
    }
}


public enum ProductionState
{
    Active,
    Inactive
}