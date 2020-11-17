using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Staff", order = 3)]
public class Staff : ScriptableObject
{
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
    public int BaseProductionAmount;

    [Space]
    public float IdleProductionSpeed = 1.0f;

    public int InfluencePerTick{

        get{
            
            switch (HomeWorld.State)
            {
                case ProductionState.Active:
                    return BaseProductionAmount;
                
                case ProductionState.Inactive:
                    return Mathf.RoundToInt(Mathf.Pow(BaseProductionAmount, 0.25f));
                    
                default:
                    return BaseProductionAmount;
            }
        }

        private set{

            BaseProductionAmount = value;
        }
    } 
}
