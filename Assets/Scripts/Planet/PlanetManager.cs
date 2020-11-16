using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(IdleProduction))]
public class PlanetManager : MonoBehaviour
{
    public Planet CurrentPlanet{

        get{ return currentPlanet;}

        set{

            currentPlanet = value;
            OnPlanetChange.Invoke();
        }
    }

    private Planet currentPlanet;

    [Header("Planet UI")]
    public Image PlanetUIImage;

    [Space]
    public Slider PlanetDominationSlider;

    private IdleProduction IdleProduction => GetComponent<IdleProduction>();

    [HideInInspector]
    public UnityEvent OnPlanetChange;

    private void Start() {
        
        if(CurrentPlanet != null){

            CurrentPlanet.State = ProductionState.Active;    
            UpdateDomination();
            SetUpDomination(CurrentPlanet);
            CurrentPlanet.OnInfluenceChange.AddListener(UpdateDomination);
        }else{

            Debug.LogError("No Planet Found!");
        }
    }

    private void OnEnable() {

        OnPlanetChange.AddListener(SetPlanetSprite);    
    }

    private void OnDisable() {
        
        OnPlanetChange.RemoveListener(SetPlanetSprite);
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

    public void SetPlanetSprite(){

        PlanetUIImage.sprite = CurrentPlanet.PlanetSprite;
    }
}
