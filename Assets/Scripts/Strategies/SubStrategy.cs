using UnityEngine;

[CreateAssetMenu(fileName = "SubStrategy", menuName = "ScriptableObjects/Sub-Strategy", order = 0)]
public class SubStrategy : ScriptableObject, IStrategy
{
    [SerializeField][Tooltip("Name to use for storing substrategy level in PlayerPrefs")] 
    private string SaveName = "REPLACE_ME"; //TODO make something safer
    [SerializeField][Tooltip("Cost")]
    private float cost = 100; //TODO hardcoded for now.
    
    public int GetLevel(PlanetName planetName)
    {
        string saveName = planetName + SaveName;
        return PlayerPrefs.GetInt(saveName);
    }

    private void SetLevel(PlanetName planetName, int value)
    {
        string saveName = planetName + SaveName;
        PlayerPrefs.SetInt(saveName, value);
    }

    public void IncrementLevel(PlanetName planetName)
    {
        int currentLevel = GetLevel(planetName);
        SetLevel(planetName, currentLevel+1);
    }

    public float Cost
    {
        get => this.cost; 
    }

}