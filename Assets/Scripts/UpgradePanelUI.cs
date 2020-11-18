using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Upgrade upgrade;

    [Header("UIReferences")] 
    public Text LvlText;
    public Button BuyButton;
    public Image LockImage;
    public Text ReqLvlText;
    public Text ReqCostText;
    
    // variabels
    private Planet currentPlanet;

    private void Awake()
    {
        this.currentPlanet = PlanetManager.instance.CurrentPlanet;
        if (currentPlanet == null)
            Debug.LogWarning("Planet not found", this);
    }

    private void Start()
    {
        if (upgrade == null)
            Debug.LogWarning("Upgrade reference is missing, please provide Upgrade", this);
        
        UpdateLevelText();
        UpdateRequirementText();
    }

    private void Update()
    {
        UpdateButtonVisibility();
    }

    public void TryToBuy()
    {
        // attempt to buy the upgrade, return true if successful
        if (this.upgrade.PurchaseUpgrade(currentPlanet))
        {
            UpdateLevelText();
            UpdateRequirementText();
            UpdateButtonVisibility();
        }
    }

    private void UpdateRequirementText()
    {
        this.ReqLvlText.text = this.upgrade.GetCurrentLevelRequirement(currentPlanet.PlanetName).ToString();
        this.ReqCostText.text = Mathf.RoundToInt(this.upgrade.GetCurrentCost(currentPlanet.PlanetName)).ToString();
    }

    private void UpdateLevelText()
    {
        this.LvlText.text = this.upgrade.GetLevel(currentPlanet.PlanetName).ToString();
    }

    private void UpdateButtonVisibility()
    {
        bool canBuy = upgrade.CanBuy(currentPlanet);
        this.BuyButton.gameObject.SetActive(canBuy);
        this.LockImage.gameObject.SetActive(!canBuy);
    }
}
