using UnityEngine;

public class InfluenceProduction : MonoBehaviour
{
    public void ProduceInfluence(Planet planet)
    {
        float totalClickIncome = 0.0f;
        // for each substrategy type
        foreach (SubStrategy subStrategy in planet.subStrategyList.SubStrategyArray)
        {
            float multiplier = 1.0f;
            float clickIncome = 0.0f;
            
            // get influence for strategy for the current planet
            clickIncome = subStrategy.GetLevel(planet.PlanetName);
            
            // get multiplier from bonuses
            float planetaryBonusMultiplier = planet.GetPlanetBonusMultiplier(subStrategy.GetStrategyType());
            multiplier *= planetaryBonusMultiplier;
            float strategyBonusMultiplier = planet.GetStrategyBonusMultiplier(subStrategy.GetStrategyType());
            multiplier *= strategyBonusMultiplier;

            totalClickIncome += clickIncome * multiplier;
            Debug.Log("Planetary bonus; " + planetaryBonusMultiplier);
            Debug.Log("Strategybonus; " + strategyBonusMultiplier);
        }
        planet.IncreaseInfluence(totalClickIncome);
        Debug.Log($"Click yielded: {totalClickIncome}");
    }
}
