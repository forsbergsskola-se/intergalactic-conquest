using UnityEngine;

public class IdleProduction : MonoBehaviour
{
    [Header("Planet")]
    public Planet[] Planets;

    public float TickDuration = 1.0f;
    
    private float elapsedTime;

    private void Update() 
    {
        //update elapsed time
        elapsedTime += Time.deltaTime;
        
        //generate income
        if(elapsedTime >= TickDuration)
        {
            GenerateIncome();
            elapsedTime -= TickDuration;
        }
    }

    private void GenerateIncome(){

        for (int i = 0; i < Planets.Length; i++)
        {
            //todo remove this condition
            if(Planets[i].Staff != null )
            {
                PerPlanetProduction(Planets[i]);
            }
        }
    }

    private void PerPlanetProduction(Planet planet){
        //Check if there are no staff on the planet to generate income
        
        //Todo generate for each staff, at the moment only a single staff is considered.
        InfluenceProduction(planet, planet.Staff);
    }

    private void InfluenceProduction(Planet planet, Staff staff) { //todo return float and then update the whole planet at once
        //TODO update when more than one staff exist.
        float multiplier = 1.0f;
        float staffIncome = 0.0f;
        
        //get the income
        staffIncome = planet.State == ProductionState.Active ? staff.BaseProductionAmount : staff.BaseProductionAmount * 0.25f;

        //get the bonuses TODO cleanup
        float planetaryBonusMultiplier = planet.GetPlanetBonusMultiplier(staff.StrategyType);
        multiplier *= planetaryBonusMultiplier;
        float strategyBonusMultiplier = planet.GetStrategyBonusMultiplier(staff.StrategyType);
        multiplier *= strategyBonusMultiplier;
        
        Debug.Log($"Planet {planet.name} : Staff {staff} has generated [(PlanetaryBonus) * (StrategyBonusMultiplier) * StaffIncome] : [{planetaryBonusMultiplier} * {strategyBonusMultiplier} * {staffIncome}] influence");
        
        planet.IncreaseInfluence(staffIncome * multiplier);
        planet.IncreaseInfluence(staff.InfluencePerTick);
    }

}

public enum IdelType{

    SolarSystem,
    Planet
}