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
    
    [HideInInspector]
    public UnityEvent<Planet> OnPlanetChange;

    private IdleProduction idleProduction => GetComponent<IdleProduction>();
    private InfluenceProduction influenceProduction => GetComponent<InfluenceProduction>();
    private PlanetUI planetUI => GetComponent<PlanetUI>();

    public bool CanProduce = true;

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

            CurrentPlanet.State = ProductionState.Active;
        }

        if(CanProduce && OnPlanet()){

            planetUI.PlanetButton.onClick.AddListener(ProduceInfuence);
            CanProduce = false;
        }
    }

    private void ProduceInfuence(){

        influenceProduction.ProduceInfluence(CurrentPlanet);
        Debug.Log(CurrentPlanet.Influence);
    }

    private void SetupUI(Planet planet){

        planetUI.SetPlanetSprite(planet);
        planetUI.SetUpDomination(planet);
    }
}
