using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Staff", menuName = "ScriptableObjects/Staff", order = 3)]
public class Staff : ScriptableObject
{
    [Header("Staff Information")]
    public string StaffName;

    [Space]
    public string Title;

    public StrategyType StrategyType;

    [Header("Influence Settings")]
    public float BaseProductionAmount = 1.0f;

    public float InfluencePerTick{

        get{
            
            return BaseProductionAmount;
        }

        private set{

            BaseProductionAmount = value;
        }
    } 
}
