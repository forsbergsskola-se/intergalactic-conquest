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
    public Text ReqLvlText;
    public Text ReqCostText;

    private void Start()
    {
        if (upgrade == null)
            Debug.LogWarning("Upgrade reference is missing, please provide Upgrade", this);
        
        UpdateLevelText();
        UpdateRequirementText();
    }

    private void Update()
    {
        UpdateBuyButton();
    }

    public void TryToBuy()
    {
        // attempt to buy the upgrade, return true if successful
        bool transactionSuccessful = this.upgrade.PurchaseUpgrade();

        if (transactionSuccessful)
        {
            UpdateLevelText();
            UpdateRequirementText();
            UpdateBuyButton();
        } 
    }

    private void UpdateRequirementText()
    {
        this.ReqLvlText.text = this.upgrade.CurrentLevelRequirement.ToString();
        this.ReqCostText.text = Mathf.RoundToInt(this.upgrade.CurrentCost).ToString();
    }

    private void UpdateLevelText()
    {
        this.LvlText.text = this.upgrade.Level.ToString();
    }

    private void UpdateBuyButton()
    {
        this.BuyButton.gameObject.SetActive(upgrade.CanBuy);
    }
}
