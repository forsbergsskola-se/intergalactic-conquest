using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/Strategy")]
public class StrategyBranch : ScriptableObject, IStrategy
{
    [SerializeField][Tooltip("Cost, hardcoded for. Ask max what TODO")] 
    private float cost = 100.0f; //TODO hardcoded for now.
    [Header("Sub-Strategies")]
    [SerializeField] private SubStrategy[] SubStrategies;

    public int Level => GetStrategyLevel();
    public float Cost => this.cost;

    private int GetStrategyLevel()
    {
        if (SubStrategies.Length <= 0)
            return 0;
        
        int lvlCount = 0;
        foreach (var strategy in SubStrategies)
        {
            lvlCount += strategy.Level;
        }
        
        return Mathf.FloorToInt((float) lvlCount / (float) SubStrategies.Length);
    }
}