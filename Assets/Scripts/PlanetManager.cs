using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    [Header("Current Planet")]
    public Planet CurrentPlanet;

    public void ChangeInfluence(int amount){

        CurrentPlanet.IncreaseInfluence(amount);
    }
}
