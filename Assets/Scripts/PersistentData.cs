using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for persistent data, i.e. Data that needs to be stored between game sessions.
/// Alternatively we can store data as PlayerPrefs or JSON.
///
/// Will hold per planet data such as Upgrades, Staff, SpendableInfluence, TotalDominanceAccumulated
///
/// Data that is requires persistence right now includes:
/// EconomyDomesticLvl
/// EconomyForeginLvl
/// MilitaryAggressiveLvl
/// MilitaryPeacemakerLvl
/// DiplomatStrongmanInfluenceLvl
/// DiplomatCommonggrounderLvl
/// 
/// </summary>

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PersistentObject", order = 2)]
public class PersistentData : ScriptableObject
{
    
    

}
