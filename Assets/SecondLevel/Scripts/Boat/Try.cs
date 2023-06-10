using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Try : BoatTowerController
{
    private ArcherTower tower;

    [Header("Text")]
    public GameObject gunInfoPanel;
    public GameObject TowerUpgrade;
    public bool upgrade = false;
    public bool bulletupgrade = false;

    private void Start()
    {
        tower = transform.GetComponentInParent<ArcherTower>();
        gunInfoPanel = GameObject.FindGameObjectWithTag("Panel").gameObject;
        TowerUpgrade = GameObject.FindGameObjectWithTag("Panelthree").gameObject;
    }

    public override void CloseTower()
    {
        gunInfoPanel.transform.DOMoveY(1500, 1);
        TowerUpgrade.transform.DOMoveY(1500, 1);
        GameManager.Instance.built = true;
        GameManager.Instance.clickc = true;
        GameManager.Instance.clicka = true;
        GameManager.Instance.clickb = true;
    }

    public override void TowerBuilt()
    {
        GameManager.Instance.built = false;
        if (gunInfoPanel != null && bulletupgrade == true && GameManager.Instance.clickd == true)
        {
            gunInfoPanel.transform.DOMoveY(900, 1);
            gunInfoPanel.GetComponentInChildren<ButtonController>().SetTower(tower);
            GameManager.Instance.clickc = false;
            GameManager.Instance.clicka = false;
            GameManager.Instance.clickb = false;
        }
        if (TowerUpgrade != null && upgrade == true)
        {
            TowerUpgrade.transform.DOMoveY(500, 1);
            TowerUpgrade.GetComponent<TowerUpgradeController>().SetTower(tower);
        }
    }
}

