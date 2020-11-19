using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/Strategy")]
public class StrategyBranch : ScriptableObject, IStrategy
{
    [Header("Sub-Strategies")]
    [SerializeField] private SubStrategy[] SubStrategies;
    
    [Header("Params")] 
    [SerializeField] private float costBase = 1.15f;
    [Tooltip("The base cost")][SerializeField] float costCoefficient = 11f;

    public int GetLevel(PlanetName planetName)
    {
        if (SubStrategies.Length <= 0)
            return 0;
        
        int lvlCount = 0;
        foreach (var strategy in SubStrategies)
        {
            lvlCount += strategy.GetLevel(planetName);
        }
        
        return Mathf.FloorToInt((float) lvlCount / (float) SubStrategies.Length);
    }
    
    public float GetCost(PlanetName planetName)
    {
        return costCoefficient * Mathf.Pow(costBase, GetLevel(planetName));
    }
    
}