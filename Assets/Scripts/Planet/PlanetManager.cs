using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(IdleProduction))]
public class PlanetManager : MonoBehaviour
{
    [Header("Planet")]
    public Planet CurrentPlanet;

    [Header("Planet UI")]
    public Slider PlanetDominationSlider;

    private IdleProduction IdleProduction => GetComponent<IdleProduction>();

    private void Start() {
        
        CurrentPlanet.State = ProductionState.Active;

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

        PlanetDominationSlider.value = CurrentPlanet.TotalInfluence;        
    }

    public void ChangeInfluence(int amount){

        CurrentPlanet.IncreaseInfluence(amount);
    }
}
