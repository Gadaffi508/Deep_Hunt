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

    public string Informatýon;

    private void Start()
    {
        tower = transform.GetComponentInParent<ArcherTower>();
        gunInfoPanel = GameObject.FindGameObjectWithTag("Panel").gameObject;
        TowerUpgrade = GameObject.FindGameObjectWithTag("Panelthree").gameObject;
    }

    public override void CloseTower()
    {
        gunInfoPanel.GetComponent<UIController>().Hide(); //yok gibi biþey
        TowerUpgrade.GetComponent<UIController>().Hide();
        GameManager.Instance.built = true;
        GameManager.Instance.clickc = true;
        GameManager.Instance.clicka = true;
        GameManager.Instance.clickb = true;
    }

    public override void TowerBuilt()
    {
        GameManager.Instance.ýnformatoýnTower = Informatýon;

        GameManager.Instance.built = false;
        if (gunInfoPanel != null && bulletupgrade == true && GameManager.Instance.clickd == true)
        {
            gunInfoPanel.GetComponent<UIController>().Show();
            gunInfoPanel.GetComponentInChildren<ButtonController>().SetTower(tower);
            GameManager.Instance.clickc = false;
            GameManager.Instance.clicka = false;
            GameManager.Instance.clickb = false;
        }
        if (TowerUpgrade != null && upgrade == true)
        {
            TowerUpgrade.GetComponent<UIController>().Show();
            TowerUpgrade.GetComponent<TowerUpgradeController>().SetTower(tower);
        }
    }
}

