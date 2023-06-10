using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tower : BoatTowerController
{
    public GameObject TowerPanel;

    private void Start()
    {
        TowerPanel = GameObject.FindGameObjectWithTag("PanelTwo").gameObject;
    }

    public override void CloseTower()
    {
        if (TowerPanel != null)
        {
            TowerPanel.transform.DOMoveY(1500, 1);
            TowerPanel.GetComponent<TowerButtonController>().SetTower(null);
            GameManager.Instance.built = true;
            GameManager.Instance.clickc = true;
            GameManager.Instance.clicka = true;
            GameManager.Instance.clickd = true;
        }
    }

    public override void TowerBuilt()
    {
        if (TowerPanel != null && GameManager.Instance.clickb == true)
        {
            TowerPanel.transform.DOMoveY(950,1);
            TowerPanel.GetComponent<TowerButtonController>().SetTower(this);
            GameManager.Instance.clickc = false;
            GameManager.Instance.clicka = false;
            GameManager.Instance.clickd = false;
        }
    }

    public GameObject TowerBuilt(GameObject _Tower)
    {
        CloseTower();
        Destroy(gameObject); 
        return Instantiate(_Tower, transform.position, transform.rotation);
    }
}
