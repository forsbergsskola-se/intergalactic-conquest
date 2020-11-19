using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IdleProduction))]
public class PlanetManager : MonoBehaviour
{
    public static PlanetManager instance = null;

    [Header("Current Planet Scriptable Object")]
    [SerializeField]
    private Planet currentPlanet;

    public Planet CurrentPlanet{

        get{ return currentPlanet;}

        set{

            currentPlanet = value;
            OnPlanetChange.Invoke(CurrentPlanet);
        }
    }
    
    [Header("Staff")]
    public List<Staff> HirableStaff = new List<Staff>();

    [HideInInspector]
    public UnityEvent<Planet> OnPlanetChange;

    private IdleProduction idleProduction => GetComponent<IdleProduction>();
    private InfluenceProduction influenceProduction => GetComponent<InfluenceProduction>();
    private PlanetUI planetUI => GetComponent<PlanetUI>();

    private bool CanProduce = true;

    public bool OnPlanet(){

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Planet")){

            return true;
        }else{

            return false;
        }
    }

    private void Awake() {
        
        if(instance == null){

            instance = this;
        }else if(instance != null){

            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        if(!OnPlanet()){

            CanProduce = true;
        }
    }

    private void Update() {
        
        if(!OnPlanet()){

            CanProduce = true;
        }

        if(CurrentPlanet != null && OnPlanet()){
            
            planetUI.UpdateUI(CurrentPlanet);
            SetupUI(CurrentPlanet);
            planetUI.UpdateDomination(CurrentPlanet);
            planetUI.UpdateInfluenceText(CurrentPlanet);

            CurrentPlanet.State = ProductionState.Active;
        }
        else if (!OnPlanet() && CurrentPlanet != null){

            CurrentPlanet.State = ProductionState.Inactive;
        }

        if(CanProduce && OnPlanet()){

            planetUI.PlanetButton.onClick.AddListener(ProduceInfuence);
            CanProduce = false;
        }
    }

    private void ProduceInfuence(){

        influenceProduction.ProduceInfluence(CurrentPlanet);
        Debug.Log(CurrentPlanet.SpendableInfluence);
    }

    private void SetupUI(Planet planet){

        planetUI.SetPlanetSprite(planet);
        planetUI.SetUpDomination(planet);
    }
}
