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
        
        CurrentPlanet.OnInfluenceChange.AddListener(UpdateDomination);
        SetUpDomination(CurrentPlanet);
        UpdateDomination();
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
