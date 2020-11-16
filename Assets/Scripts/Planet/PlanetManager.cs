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

    [SerializeField]
    private Planet currentPlanet;

    [Header("Planet UI")]
    public Image PlanetUIImage;

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

    private void Update() {
        
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Planet")){
            
            OnPlanet = true;
        }else{

            OnPlanet = false;
        }

        if(OnPlanet){

            PlanetUIImage = GameObject.FindGameObjectWithTag("PlanetUI").GetComponent<Image>();
            PlanetDominationSlider = GameObject.FindGameObjectWithTag("DominationBar").GetComponent<Slider>();
        }

        if(CurrentPlanet != null){

            CurrentPlanet.State = ProductionState.Active;    

            SetUpDomination(CurrentPlanet);
            UpdateDomination();
        }else{

            Debug.LogError("No Planet Found!");
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

    public void ChangeInfluence(int amount){

        CurrentPlanet.IncreaseInfluence(amount);
    }

    public void SetPlanetSprite(){

        if(OnPlanet){

            PlanetUIImage.sprite = CurrentPlanet.PlanetSprite;
        }
    }
}
