using UnityEngine;

[CreateAssetMenu(fileName = "SubStrategy", menuName = "ScriptableObjects/Sub-Strategy", order = 0)]
public class SubStrategy : ScriptableObject, IStrategy
{
    [SerializeField][Tooltip("Name to use for storing substrategy level in PlayerPrefs")] 
    private string SaveName = "REPLACE_ME"; //TODO make something safer
    
    [Header("Params")] 
    [SerializeField] private float costBase = 1.15f;
    [Tooltip("The base cost")][SerializeField] float costCoefficient = 11f;
    
    
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

    public float GetCost(PlanetName planetName)
    {
        return costCoefficient * Mathf.Pow(costBase, GetLevel(planetName));
    }
}