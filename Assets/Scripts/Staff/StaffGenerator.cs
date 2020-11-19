using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffGenerator : MonoBehaviour
{
    public Staff testStaff;

    [Header("Wordlists")]
    public Wordlist FirstName;
    public Wordlist LastName;

    [Space]
    public Wordlist Title;

    private void Start() {
        
        testStaff = GenerateStaff();
    }

    public Staff GenerateStaff(){

        Staff staff = ScriptableObject.CreateInstance<Staff>();

        staff.Name = GetRandomWord(FirstName) + " " + GetRandomWord(LastName);

        staff.Title = GetRandomWord(Title);

        staff.StrategyType = GetRandomStrategy(Random.Range(0, 9));

        return staff;
    }

    private string GetRandomWord(Wordlist list){

        return list.Words[Random.Range(0, list.Words.Length)];
    }

    private StrategyType GetRandomStrategy(int num){

        switch (num)
        {
            case 1:
                return StrategyType.Diplomacy;
            case 2:
                return StrategyType.DiplomatCommongrounder;
            case 3:
                return StrategyType.DiplomatStrongman;
            case 4:
                return StrategyType.Military;
            case 5:
                return StrategyType.MilitaryAggressive;
            case 6:
                return StrategyType.MilitaryPeacemaker;      
            case 7:
                return StrategyType.Economics;
            case 8:
                return StrategyType.EconomyDomestic;
            case 9:
                return StrategyType.EconomyForeign;
            default:
                return StrategyType.Diplomacy;                                  
        }
    }
}

[System.Serializable]
public class Wordlist
{
    public string[] Words;
}
