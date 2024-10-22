using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentTechPoints;
    public int totalTechPoints;
    public int totalPassivePerSecond;

    public int clickUpgradeCost;
    public int clickUpgrades;
    public TMP_Text ClickUpgradeCostText;
    public TMP_Text ClickUpgradeAmountText;
    
    public int passive1Cost;
    public int passive1Upgrades;
    public TMP_Text passive1CostText;
    public TMP_Text passive1AmountText;
    
    public int passive2Cost;
    public int passive2Upgrades;
    public TMP_Text passive2CostText;
    public TMP_Text passive2AmountText;
    
    public float secondTimer;
    public TMP_Text TechPointCounter;
    public TMP_Text TechPerSecondText;
    public TMP_Text TechPerClickText;
    void Start()
    {
        secondTimer = 0;
        clickUpgrades = 1;
        clickUpgradeCost = 25;

        passive1Upgrades = 0;
        passive1Cost = 50;

        passive2Upgrades = 0;
        passive2Cost = 250;
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer -= Time.deltaTime;
        if (secondTimer < 0)
        {
            secondTimer = 1;
            TechPointCounter.text = "" + currentTechPoints + " Tech Points";

            totalPassivePerSecond = (passive1Upgrades * 2) + (passive2Upgrades * 10);
            TechPerSecondText.text = "" + totalPassivePerSecond + " Tech per Second";
            TechPerClickText.text = "" + clickUpgrades + " Tech per Click";
            
            currentTechPoints = currentTechPoints + totalPassivePerSecond;
            totalTechPoints = totalTechPoints + totalPassivePerSecond;
        }
    }
    public void onTechClick()
    {
        currentTechPoints = currentTechPoints + clickUpgrades;
        TechPointCounter.text = "" + currentTechPoints + " Tech Points";
    }

    public void onClickUpgrade()
    {
        if (currentTechPoints >= clickUpgradeCost)
        {
            currentTechPoints = currentTechPoints - clickUpgradeCost;
            clickUpgrades = clickUpgrades + 1;
            clickUpgradeCost = clickUpgradeCost + 25;
            ClickUpgradeAmountText.text = "" + clickUpgrades;
            ClickUpgradeCostText.text = "" + clickUpgradeCost + " Tech";
        }
    }

    public void onPassiveUpgrade1Click()
    {
        if (currentTechPoints >= passive1Cost)
        {
            currentTechPoints = currentTechPoints - passive1Cost;
            passive1Upgrades = passive1Upgrades + 1;
            passive1Cost = passive1Cost + 50;
            passive1AmountText.text = "" + passive1Upgrades;
            passive1CostText.text = "" + passive1Cost + " Tech";
        }
    }
    
    public void onPassiveUpgrade2Click()
    {
        if (currentTechPoints >= passive2Cost)
        {
            currentTechPoints = currentTechPoints - passive2Cost;
            passive2Upgrades = passive2Upgrades + 1;
            passive2Cost = passive2Cost + 250;
            passive2AmountText.text = "" + passive2Upgrades;
            passive2CostText.text = "" + passive2Cost + " Tech";
        }
    }
}
