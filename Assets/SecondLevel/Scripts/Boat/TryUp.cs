using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryUp : BoatTowerController
{
    private ArcherUpTower tower;

    [Header("Text")]
    public GameObject gunInfoPanel;
    public GameObject TowerUpgrade;
    public bool upgrade = false;

    private void Start()
    {
        tower = transform.GetComponentInParent<ArcherUpTower>();
        TowerUpgrade = GameObject.FindGameObjectWithTag("PanelFive").gameObject;
    }

    public override void CloseTower()
    {
        TowerUpgrade.transform.DOMoveY(1500, 1);
    }

    public override void TowerBuilt()
    {
        if (TowerUpgrade != null && upgrade == true)
        {
            TowerUpgrade.transform.DOMoveY(500, 1);
        }
    }
    public void HealthUpgrade()
    {
        tower.HealthUpgrade();
    }
    public void DamageDecrease()
    {
        tower.DamageDecrease();
    }
}
