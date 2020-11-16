using UnityEngine;

public class IdleProduction : MonoBehaviour
{
    [Header("Idle Production Settings")]
    [SerializeField]
    private IdelType ProductionType = IdelType.Planet;

    [Header("Planet")]
    public Planet[] Planets;

    private float elapsedTime;

    private void Update() {
        
        if(ProductionType == IdelType.Planet && Planets.Length > 1){

            Debug.LogError($"Your production type is set to {ProductionType} but you have more than one planet. {Planets}");
        }

        Idle();
    }

    private void Idle(){

        if(ProductionType == IdelType.Planet){

            PlanetProduction(Planets[0]);
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

    private void UpdateTime(){

        elapsedTime += Time.deltaTime;
    }
}

public enum IdelType{

    SolarSystem,
    Planet
}