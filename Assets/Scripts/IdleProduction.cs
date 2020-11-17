using UnityEngine;

public class IdleProduction : MonoBehaviour
{
    [Header("Planet")]
    public Planet[] Planets;

    private float elapsedTime;

    private void Update() {
        
        Idle();
    }

    private void Idle(){

        for (int i = 0; i < Planets.Length; i++)
        {
            if(Planets[i].Staff != null ){
                
            PlanetProduction(Planets[i]);
            }
        }
    }

    private void PlanetProduction(Planet planet){

        if(planet.Staff != null){

            UpdateTime();
            
            if(elapsedTime >= planet.Staff.IdleProductionSpeed){
                
                InfluenceProduction(planet, planet.Staff);
                elapsedTime -= planet.Staff.IdleProductionSpeed;
            }
        }
    }

    private void InfluenceProduction(Planet planet, Staff staff){
        


        planet.IncreaseInfluence(staff.InfluencePerTick);
        Debug.Log($"{staff} has produced {staff.InfluencePerTick} influence");
    }

    private int IdleProductionAmount(Planet planet, Staff staff){
        
        if(planet.State == ProductionState.Active){

            return staff.BaseProductionAmount;
        }
        else if(planet.State == ProductionState.Inactive){

            return Mathf.RoundToInt(staff.BaseProductionAmount * 0.25f);
        }

        return 0;
    }

    private void UpdateTime(){

        elapsedTime += Time.deltaTime;
    }
}

public enum IdelType{

    SolarSystem,
    Planet
}