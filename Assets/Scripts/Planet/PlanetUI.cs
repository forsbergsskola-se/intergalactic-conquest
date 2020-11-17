using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{
    public Image PlanetUIImage;
    public Button PlanetButton;

    [Space]
    public Slider PlanetDominationSlider;

    public void UpdateUI(Planet planet){

        PlanetButton = GameObject.FindWithTag("PlanetUI").GetComponent<Button>();
        PlanetUIImage = GameObject.FindWithTag("PlanetUI").GetComponent<Image>();
        PlanetDominationSlider = GameObject.FindWithTag("DominationBar").GetComponent<Slider>();
    }

    public void SetUpDomination(Planet planet){
        
        PlanetDominationSlider.maxValue = planet.InfluenceGoal;
    }

    public void UpdateDomination(Planet planet){

        PlanetDominationSlider.value = planet.TotalInfluence;        
    }

    public void SetPlanetSprite(Planet planet){

        PlanetUIImage.sprite = planet.PlanetSprite;
    }
}
