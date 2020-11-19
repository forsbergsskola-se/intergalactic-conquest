using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffCard : MonoBehaviour
{
    public Staff staff;

    [Space]
    public bool IsHired;

    [Header("Buttons")]
    public Button HireButton;

    [Space]
    public Button FireButton;

    [Header("UI")]
    public Text Name;

    [Space]
    public Text Title;

    [Space]
    public Text Stratgey;

    private void Update() {

        if(staff != null){

            SetupUI(staff);        
        }
    }

    public void HireStaff(){

        PlanetManager.instance.CurrentPlanet.Staff = this.staff;

        Destroy(gameObject);

        Debug.Log(PlanetManager.instance.CurrentPlanet.Staff);
    }

    public void FireStaff(){

        PlanetManager.instance.CurrentPlanet.FireStaff();
        Debug.Log(PlanetManager.instance.CurrentPlanet.Staff);
    }

    public void SetupUI(Staff staff){

        Name.text = staff.StaffName;
        Title.text = staff.Title;
        Stratgey.text = "Strategy: " + staff.StrategyType;        
    }
}
