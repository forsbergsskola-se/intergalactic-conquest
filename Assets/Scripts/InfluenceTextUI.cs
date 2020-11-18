using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InfluenceTextUI : MonoBehaviour
{
    private Text influenceText;
    private Planet planet;
    private void Awake()
    {
        this.influenceText = GetComponent<Text>();
        planet = PlanetManager.instance.CurrentPlanet;
        if (planet == null)
            Debug.LogWarning("Current planet not found", this);
    }

    void Update()
    {
        this.influenceText.text = Mathf.RoundToInt(planet.SpendableInfluence).ToString();
    }
}
