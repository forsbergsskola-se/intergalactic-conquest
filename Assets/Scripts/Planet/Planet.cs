using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet", order = 1)]
public class Planet : ScriptableObject
{
    [Header("Planet Data")]
    public Sprite PlanetSprite;
    
    [Header("Planet Settings")]
    public ProductionState State = ProductionState.Inactive;

    [Header(" Planet Staff & Upgrades")]
    public Staff Staff;

    [Space]
    public Upgrade[] Upgrades;

    [Header("Domination")]
    public int InfluenceGoal;

    [Header("Influence")]
    [SerializeField]
    private int influence;

    [Space]
    public int TotalInfluence;

    public int Influence{

        get{

            return influence;
        }

        set{

            influence = value;

            if(influence >= TotalInfluence){

                TotalInfluence = influence;
            }

            OnInfluenceChange.Invoke();
        }
    }


    [HideInInspector]
    public UnityEvent OnInfluenceChange;

    public void IncreaseInfluence(int amount){

        Influence += amount;
    }

    public void DecreaseInfluence(int amount){

        Influence -= amount;
    }
}


public enum ProductionState
{
    Active,
    Inactive
}