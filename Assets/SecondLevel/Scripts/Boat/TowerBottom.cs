using DG.Tweening;
using UnityEngine;

public class TowerBottom : BoatTowerController
{
    public GameObject TowerPanel;

    private void Start()
    {
        TowerPanel = GameObject.FindGameObjectWithTag("Panelfour").gameObject;
    }

    public override void CloseTower()
    {
        if (TowerPanel != null)
        {
            TowerPanel.transform.DOMoveY(1500, 1);
            TowerPanel.GetComponent<TowerButtomController>().SetTower(null);
            GameManager.Instance.clickb = true;
            GameManager.Instance.clicka = true;
            GameManager.Instance.clickd = true;
        }
    }

    public override void TowerBuilt()
    {
        if (TowerPanel != null && GameManager.Instance.clickc == true)
        {
            TowerPanel.transform.DOMoveY(950, 1);
            TowerPanel.GetComponent<TowerButtomController>().SetTower(this);
            GameManager.Instance.clickb = false;
            GameManager.Instance.clicka = false;
            GameManager.Instance.clickd = false;
        }
    }

    public GameObject TowerBuilt(GameObject _Tower)
    {
        CloseTower();
        Destroy(gameObject);
        return Instantiate(_Tower, transform.position, Quaternion.identity);
    }
}
