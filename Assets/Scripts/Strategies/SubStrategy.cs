using UnityEngine;

[CreateAssetMenu(fileName = "SubStrategy", menuName = "ScriptableObjects/Sub-Strategy", order = 0)]
public class SubStrategy : ScriptableObject, IStrategy
{
    [SerializeField][Tooltip("Name to use for storing substrategy level in PlayerPrefs")] 
    private string SaveName = "REPLACE_ME"; //TODO make something safer
    [SerializeField][Tooltip("Cost")]
    private float cost = 100; //TODO hardcoded for now.

    public int Level
    {
        get => PlayerPrefs.GetInt(SaveName, 0);
        set => PlayerPrefs.SetInt(SaveName, value);
    }
    public float Cost
    {
        get => this.cost; 
    }

}