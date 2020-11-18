using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/Strategy")]
public class StrategyBranch : ScriptableObject, IStrategy
{
    [SerializeField][Tooltip("Cost, hardcoded for. Ask max what TODO")] 
    private float cost = 100.0f; //TODO hardcoded for now.
    [Header("Sub-Strategies")]
    [SerializeField] private SubStrategy[] SubStrategies;
    
    public float Cost => this.cost;
    
    /* TODO
    public float GetCost(PlanetName planetName)
    {
        
        return 
    }
    */

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
}