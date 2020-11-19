using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Staff", order = 3)]
public class Staff : ScriptableObject
{
    public StrategyType StrategyType;
    
    [Header("Staff Information")]
    public string Name;

    [Space]
    public string Title;

    [Space]
    public Planet HomeWorld;

    [FormerlySerializedAs("Strategy")] [Header("Strategy Specialization")]
    public StrategyBranch strategyBranch;

    [Space]
    public SubStrategy SubStrategy;

    [Header("Influence Settings")]
    public float BaseProductionAmount = 1.0f;

    //[Space]
    //public float IdleProductionSpeed = 1.0f;

    public float InfluencePerTick{

        get{
            
            switch (HomeWorld.State)
            {
                case ProductionState.Active:
                    return BaseProductionAmount;
                
                case ProductionState.Inactive:
                    return BaseProductionAmount * 0.25f;
                    
                default:
                    return BaseProductionAmount;
            }
        }

        private set{

            BaseProductionAmount = value;
        }
    } 
}
