using UnityEngine;

public class InfluenceProduction : MonoBehaviour
{
    [Header("Influence Production")]
    public int BaseInfluenceProduction = 5;

    public void ProduceInfluence(Planet planet){

        planet.IncreaseInfluence(BaseInfluenceProduction);
    }
}
