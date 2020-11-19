using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "SubStrategyList", menuName = "ScriptableObjects/SubStrategyList", order = 12)]
public class UpgradeList : ScriptableObject
{
    [Tooltip("The 9 upgrades that each planet will have")][SerializeField] private Upgrade[] upgradeList;
    
    private Dictionary<StrategyType, Upgrade> upgradeLookupTable;
    
    private void GenerateLookupTable()
    {
        upgradeLookupTable = new Dictionary<StrategyType, Upgrade>();
        foreach (var u in upgradeList)
        {
            upgradeLookupTable.Add(u.StrategyType, u);
        }
    }

    private void OnEnable()
    {
        GenerateLookupTable();
    }
    
    public Upgrade GetUpgrade(StrategyType strategyType)
    {
        /*
        if(upgradeLookupTable == null)
            GenerateLookupTable();
        */
    
        Upgrade u;
        if (!upgradeLookupTable.TryGetValue(strategyType, out u)) 
            Debug.LogError("upgrade not found in list", this);
    
        return u;
    }

    public void ResetUpgrades(PlanetName planetName)
    {
        foreach (var upgrade in upgradeList)
        {
            upgrade.Reset(planetName);
        }
    }

}
