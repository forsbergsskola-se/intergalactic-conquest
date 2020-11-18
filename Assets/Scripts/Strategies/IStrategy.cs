using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStrategy
{
    int GetLevel(PlanetName planetName);
    float Cost { get; }
}
