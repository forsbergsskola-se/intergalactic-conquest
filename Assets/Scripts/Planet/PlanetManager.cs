using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlanetManager : MonoBehaviour
{
    [Header("Planet")]
    public Planet CurrentPlanet;

    [Header("Planet UI")]
    public Slider PlanetDominationSlider;

    private void Start() {
        
        if(CurrentPlanet != null){
            
            UpdateDomination();
            SetUpDomination(CurrentPlanet);
            CurrentPlanet.OnInfluenceChange.AddListener(UpdateDomination);
        }
    }

    public void SetUpDomination(Planet planet){

        PlanetDominationSlider.maxValue = planet.InfluenceGoal;
    }

    private void UpdateDomination(){

        PlanetDominationSlider.value = CurrentPlanet.Influence;        
    }

    public void ChangeInfluence(int amount){

        CurrentPlanet.IncreaseInfluence(amount);
    }
}
