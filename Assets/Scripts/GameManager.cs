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

    public GameObject passive1Row;
    public int passive1Cost;
    public int passive1Upgrades;
    public TMP_Text passive1CostText;
    public TMP_Text passive1AmountText;
    
    public GameObject passive2Row;
    public int passive2Cost;
    public int passive2Upgrades;
    public TMP_Text passive2CostText;
    public TMP_Text passive2AmountText;
    
    public GameObject passive3Row;
    public int passive3Cost;
    public int passive3Upgrades;
    public TMP_Text passive3CostText;
    public TMP_Text passive3AmountText;
    
    public GameObject passive4Row;
    public int passive4Cost;
    public int passive4Upgrades;
    public TMP_Text passive4CostText;
    public TMP_Text passive4AmountText;
    
    public GameObject passive5Row;
    public int passive5Cost;
    public int passive5Upgrades;
    public TMP_Text passive5CostText;
    public TMP_Text passive5AmountText;
    
    public float secondTimer;
    public TMP_Text TechPointCounter;
    public TMP_Text TechPerSecondText;
    public TMP_Text TechPerClickText;

    public GameObject StatsWindow;
    public TMP_Text TotalTechPointsText;
    public TMP_Text TotalPassiveEarned;
    public int totalPassiveEarned;
    public TMP_Text TotalClicksText;
    public int totalClicks;
    public TMP_Text TotalEarnedByClicks;
    public int totalEarnedByClicks;

    public GameObject computer1;
    public GameObject computer2;
    public GameObject computer3;
    public GameObject lights1;
    public GameObject lights2;
    public GameObject storage1;
    public GameObject storage2;
    public GameObject storage3;

    public GameObject pauseScreen;
    

    void Start()
    {
        secondTimer = 0;
        clickUpgrades = 1;
        clickUpgradeCost = 25;

        passive1Upgrades = 0;
        passive1Cost = 100;

        passive2Upgrades = 0;
        passive2Cost = 350;
        
        passive3Upgrades = 0;
        passive3Cost = 4500;
        
        passive4Upgrades = 0;
        passive4Cost = 30000;
        
        passive5Upgrades = 0;
        passive5Cost = 375000;
    }

    // Update is called once per frame
    void Update()
    {
        //passive tech income
        secondTimer -= Time.deltaTime;
        if (secondTimer < 0)
        {
            secondTimer = 1;
            TechPointCounter.text = "" + currentTechPoints + " Tech";

            totalPassivePerSecond = (passive1Upgrades * 2) + (passive2Upgrades * 10) + (passive3Upgrades * 100) + (passive4Upgrades * 1000) + (passive5Upgrades * 15000);
            totalPassiveEarned = totalPassiveEarned + totalPassivePerSecond;
            TechPerSecondText.text = "" + totalPassivePerSecond + "  per Second";
            TechPerClickText.text = "" + clickUpgrades + "  per Click";
            
            currentTechPoints = currentTechPoints + totalPassivePerSecond;
            totalTechPoints = totalTechPoints + totalPassivePerSecond;
        }
        
        //stats window updates
        TotalTechPointsText.text = "" + totalTechPoints;
        TotalPassiveEarned.text = "" + totalPassiveEarned;
        TotalClicksText.text = "" + totalClicks;
        TotalEarnedByClicks.text = "" + totalEarnedByClicks;
        
        //pause screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void onStatsClick()
    {
        StatsWindow.SetActive(true);
    }

    public void onCloseStatsClick()
    {
        StatsWindow.SetActive(false);
    }

    public void onResumeClick()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
    public void onTechClick()
    {
        totalClicks = totalClicks + 1;
        currentTechPoints = currentTechPoints + clickUpgrades;
        totalEarnedByClicks = totalEarnedByClicks + clickUpgrades;
        totalTechPoints = totalTechPoints + clickUpgrades;
        TechPointCounter.text = "" + currentTechPoints + " Tech";
    }

    public void onClickUpgrade()
    {
        if (currentTechPoints >= clickUpgradeCost)
        {
            currentTechPoints = currentTechPoints - clickUpgradeCost;
            clickUpgrades = clickUpgrades + 1;
            clickUpgradeCost = clickUpgradeCost + 12;
            ClickUpgradeAmountText.text = "" + clickUpgrades;
            ClickUpgradeCostText.text = "" + clickUpgradeCost + "TP";

            if (clickUpgrades == 2)
            {
                passive1Row.SetActive(true);
            }

            if (clickUpgrades == 5)
            {
                computer1.SetActive(false);
                computer2.SetActive(true);
            }

            if (clickUpgrades == 20)
            {
                computer2.SetActive(false);
                computer3.SetActive(true);
            }
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
            passive1CostText.text = "" + passive1Cost + "TP";
            
            if (passive1Upgrades == 1)
            {
                passive2Row.SetActive(true);
            }

            if (passive1Upgrades == 10)
            {
                lights1.SetActive(false);
                lights2.SetActive(true);
            }
        }
    }
    
    public void onPassiveUpgrade2Click()
    {
        if (currentTechPoints >= passive2Cost)
        {
            currentTechPoints = currentTechPoints - passive2Cost;
            passive2Upgrades = passive2Upgrades + 1;
            passive2Cost = passive2Cost + 175;
            passive2AmountText.text = "" + passive2Upgrades;
            passive2CostText.text = "" + passive2Cost + "TP";
            
            if (passive2Upgrades == 1)
            {
                passive3Row.SetActive(true);
            }

            if (passive2Upgrades == 5)
            {
                storage1.SetActive(false);
                storage2.SetActive(true);
            }

            if (passive2Upgrades == 15)
            {
                storage2.SetActive(false);
                storage3.SetActive(true);
            }
        }
    }
    
    public void onPassiveUpgrade3Click()
    {
        if (currentTechPoints >= passive3Cost)
        {
            currentTechPoints = currentTechPoints - passive3Cost;
            passive3Upgrades = passive3Upgrades + 1;
            passive3Cost = passive3Cost + 2250;
            passive3AmountText.text = "" + passive3Upgrades;
            passive3CostText.text = "" + passive3Cost + "TP";
            
            if (passive3Upgrades == 1)
            {
                passive4Row.SetActive(true);
            }
        }
    }
    
    public void onPassiveUpgrade4Click()
    {
        if (currentTechPoints >= passive4Cost)
        {
            currentTechPoints = currentTechPoints - passive4Cost;
            passive4Upgrades = passive4Upgrades + 1;
            passive4Cost = passive4Cost + 15000;
            passive4AmountText.text = "" + passive4Upgrades;
            passive4CostText.text = "" + passive4Cost + "TP";
            
            if (passive4Upgrades == 1)
            {
                passive5Row.SetActive(true);
            }
        }
    }
    public void onPassiveUpgrade5Click()
    {
        if (currentTechPoints >= passive5Cost)
        {
            currentTechPoints = currentTechPoints - passive5Cost;
            passive5Upgrades = passive5Upgrades + 1;
            passive5Cost = passive5Cost + 187500;
            passive5AmountText.text = "" + passive5Upgrades;
            passive5CostText.text = "" + passive5Cost + "TP";
        }
    }
}
