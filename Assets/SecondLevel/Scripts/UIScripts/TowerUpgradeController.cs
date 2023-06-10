using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeController : MonoBehaviour
{
    [SerializeField] TowerUpgrade towerUpgrade;

    private ArcherTower currentTower;

    public void SetTower(ArcherTower towerU)
    {
        currentTower = towerU;
    }

    private void OnEnable()
    {
        towerUpgrade.OnButtonClick += UpgradeClick;
    }

    private void OnDisable()
    {
        towerUpgrade.OnButtonClick -= UpgradeClick;
    }

    private void UpgradeClick()
    {
        if (currentTower != null)
        {
            currentTower.UpgradeTowerButton();
        }
    }
}
