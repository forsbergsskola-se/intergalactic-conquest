using UnityEngine;

/*
 * I Couldnt find any influence script so I created this placeholder.
 */
[CreateAssetMenu(fileName = "Influence", menuName = "ScriptableObjects/Influence", order = 6)]
public class Influence : ScriptableObject
{
    [SerializeField] private string saveName = "REPLACE_ME";
    public float CurrentInfluence
    {
        get => PlayerPrefs.GetFloat(saveName, 0f);
        set => PlayerPrefs.SetFloat(saveName, value);
    }
}
