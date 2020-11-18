using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{   
    [Header("Influence")]
    public Text InfluenceAmount;
    

    [Header("Planet")]
    public Image PlanetUIImage;
    public Button PlanetButton;

    [Header("Domination")]
    public Slider PlanetDominationSlider;

    public void UpdateUI(Planet planet){

        PlanetButton = GameObject.FindWithTag("PlanetUI").GetComponent<Button>();
        PlanetUIImage = GameObject.FindWithTag("PlanetUI").GetComponent<Image>();
        PlanetDominationSlider = GameObject.FindWithTag("DominationBar").GetComponent<Slider>();
        InfluenceAmount = GameObject.FindWithTag("InfluenceUI").GetComponent<Text>();
    }

    public void SetUpDomination(Planet planet){
        
        PlanetDominationSlider.maxValue = planet.InfluenceGoal;
    }

    public void UpdateDomination(Planet planet){

        PlanetDominationSlider.value = planet.TotalInfluence;        
    }

    public void UpdateInfluenceText(Planet planet){

        InfluenceAmount.text = "" + planet.SpendableInfluence;
    }

    public void SetPlanetSprite(Planet planet){

        PlanetUIImage.sprite = planet.PlanetSprite;
    }
}
