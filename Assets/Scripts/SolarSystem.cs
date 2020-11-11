using UnityEngine;

/// <summary>
/// This class is responsible for the solar system.
/// A solar system has planets
/// 
/// Can for example contain logic for populating the solar system UI.
/// </summary>
public class SolarSystem : MonoBehaviour
{
    [Tooltip("Holds the planets for this solar system. Populate Planets by drag and drop")] 
    public Planet[] PlanetArray;
}
