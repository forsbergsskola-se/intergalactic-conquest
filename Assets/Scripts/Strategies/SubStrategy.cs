using UnityEngine;

[CreateAssetMenu(fileName = "SubStrategy", menuName = "ScriptableObjects/Sub-Strategy", order = 0)]
public class SubStrategy : ScriptableObject 
{
    public int Level;
    private int cost = 100; //TODO hardcoded for now.
    public int Cost
    {
        get => this.cost; 
    }
    
}