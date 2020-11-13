using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/Strategy")]
public class Strategy : ScriptableObject 
{
    [Header("Sub-Strategies")]
    public SubStrategy[] SubStrategies;
}