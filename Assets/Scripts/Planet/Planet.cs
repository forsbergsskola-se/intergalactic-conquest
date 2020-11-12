using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Planet", menuName = "ScriptableObjects/Planet", order = 1)]
/*
 * A planet has staff available for hire as well as Economy- Military- and Diplomat upgrades
 */
public class Planet : ScriptableObject
{
    [Tooltip("This planets' staff. Populate Planets by drag and drop")] 
    public Staff[] staffArray;

    [Tooltip("This planets' upgrades. Populate Planets by drag and drop")] 
    public Upgrade[] upgradeArray;

    [Header("Domination")]
    public int InfluenceGoal;

    [Header("Influence")]
    [HideInInspector]
    public UnityEvent OnInfluenceChange;

    public int Influence{

        get => PlayerPrefs.GetInt(this.name, 0);

        set{

            PlayerPrefs.SetInt(this.name, value);
            OnInfluenceChange.Invoke();
        }
    }

    public void IncreaseInfluence(int amount){

        Influence += amount;
    }

    public void DecreaseInfluence(int amount){

        Influence -= amount;
    }
}
