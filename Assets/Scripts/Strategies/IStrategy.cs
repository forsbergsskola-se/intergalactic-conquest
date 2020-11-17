using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStrategy
{
    int Level { get; }
    float Cost { get; }
}
