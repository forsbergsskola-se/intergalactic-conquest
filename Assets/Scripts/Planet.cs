using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Planet", order = 1)]
/*
 * A planet has staff available for hire as well as Economy- Military- and Diplomat upgrades
 */
public class Planet : ScriptableObject
{
    [Tooltip("This planets' staff. Populate Planets by drag and drop")] 
    public Staff[] staffArray;
    [Tooltip("This planets' upgrades. Populate Planets by drag and drop")] 
    public Upgrade[] upgradeArray;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
