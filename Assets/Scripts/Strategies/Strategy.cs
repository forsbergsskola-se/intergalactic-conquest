using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/Strategy")]
public class Strategy : ScriptableObject 
{
    [Header("Sub-Strategies")]
    public SubStrategy[] SubStrategies;

    public int Level{ get{ return GetStrategyLevel(); } private set{} }

    public int GetStrategyLevel(){

        int level = 0;

        foreach (var strategy in SubStrategies){
            
            Level += strategy.Level;
        }

        return level / 2;
    }
}