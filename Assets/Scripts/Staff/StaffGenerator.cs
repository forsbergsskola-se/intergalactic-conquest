using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffGenerator : MonoBehaviour
{
    [Header("StaffCards")]
    public GameObject StaffCard;

    [Space]
    public Transform Menu;

    [Space]
    public int GenerateAmount;

    [Header("Staff")]
    public Staff HiredStaff;

    [Space]
    public StaffCard HiredCard;

    [Header("Wordlists")]
    public Wordlist FirstName;
    public Wordlist LastName;

    [Space]
    public Wordlist Title;
    
    private void Update() {

        if(PlanetManager.instance.CurrentPlanet.IsStaffed){

            HiredStaff = PlanetManager.instance.CurrentPlanet.Staff;
        }        

        if(HiredStaff != null){

            HiredCard.staff = HiredStaff;
        }

        if(PlanetManager.instance.OnPlanet()){

            for (int i = 0; i < GenerateAmount; i++)
            {
                CreateStaff(GenerateStaff());
                GenerateAmount--;
            }
        }

        if(PlanetManager.instance.OnPlanet() && PlanetManager.instance.CurrentPlanet.IsStaffed){

            
        }
    }

    public void CreateStaff(Staff staff){

        GameObject clone = Instantiate(StaffCard, Menu);
        clone.GetComponent<StaffCard>().staff = staff;
    }

    public Staff GenerateStaff(){

        Staff staff = ScriptableObject.CreateInstance<Staff>();

        staff.StaffName = GetRandomWord(FirstName) + " " + GetRandomWord(LastName);

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
