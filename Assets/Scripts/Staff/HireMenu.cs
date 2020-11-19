using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireMenu : MonoBehaviour
{
    public GameObject[] DisableObjects;

    public GameObject StaffHireMenu;

    private bool HireIsHidden = true;
    
    private bool IsToggled = false;
    
    private void Update() {
        
        
    }

    public void ToggleObjects(){

        foreach (var objects in DisableObjects)
        {
            objects.SetActive(IsToggled);
        }

        if(IsToggled){

            IsToggled = false;
        }else{

            IsToggled = true;
        }   
    }

    public void ToggleMenu(){

        StaffHireMenu.SetActive(HireIsHidden);

        if(HireIsHidden){

            HireIsHidden = false;
        }else{

            HireIsHidden = true;
        }   
    }
}
