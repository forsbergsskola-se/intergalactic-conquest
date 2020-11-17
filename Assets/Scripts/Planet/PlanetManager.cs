using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IdleProduction))]
public class PlanetManager : MonoBehaviour
{
    public static PlanetManager instance = null;

    public Planet CurrentPlanet{

        get{ return currentPlanet;}

        set{

            currentPlanet = value;
            OnPlanetChange.Invoke();
        }
    }

    private Planet currentPlanet;

    public int InfluenceAmountPerClick = 5;

    [Header("Planet UI")]
    public Image PlanetUIImage;
    public Button PlanetButton;

    [Space]
    public Slider PlanetDominationSlider;

    private IdleProduction IdleProduction => GetComponent<IdleProduction>();

    [HideInInspector]
    public UnityEvent OnPlanetChange;

    private bool OnPlanet = false;

    private void Start() {

        if(instance == null){

            instance = this;
        }else if(instance != null){

            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    scene

    private void Update() {
        
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Planet")){
            
            OnPlanet = true;
        }
        else{

            OnPlanet = false;
        }

        if(OnPlanet){

            PlanetUIImage = GameObject.FindGameObjectWithTag("PlanetUI").GetComponent<Image>();
            PlanetDominationSlider = GameObject.FindGameObjectWithTag("DominationBar").GetComponent<Slider>();
            PlanetButton = GameObject.FindGameObjectWithTag("PlanetUI").GetComponent<Button>();

            SetUpDomination(CurrentPlanet);
        }

        if(CurrentPlanet != null){

            CurrentPlanet.State = ProductionState.Active;    
            UpdateDomination();
        }else{

            Debug.LogWarning("No Planet Found!");
        }
    }

    private void OnValidate() {

        OnPlanetChange.AddListener(SetPlanetSprite);
    }
    
    private void OnDisable() {
        
        OnPlanetChange.RemoveListener(SetPlanetSprite);
    }
    public void SetUpDomination(Planet planet){
        
        PlanetDominationSlider.maxValue = planet.InfluenceGoal;
    }

    private void UpdateDomination(){

        if(OnPlanet){

            PlanetDominationSlider.value = CurrentPlanet.TotalInfluence;        
        }
    }

    public void ProduceInfluence(){

        CurrentPlanet.IncreaseInfluence(InfluenceAmountPerClick);
    }

    public void SetPlanetSprite(){

        if(OnPlanet){

            PlanetUIImage.sprite = CurrentPlanet.PlanetSprite;
        }
    }
}
