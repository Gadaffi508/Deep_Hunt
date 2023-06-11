using DG.Tweening;
using UnityEngine;

public class TowerUp : BoatTowerController
{
    public GameObject TowerPanel;
    public int areaI;

    private void Start()
    {
        TowerPanel = GameObject.FindGameObjectWithTag("PanelFive").gameObject;
    }

    public override void CloseTower()
    {
        if (TowerPanel != null)
        {
            TowerPanel.GetComponent<UIController>().Hide();
            TowerPanel.GetComponent<TowerTopController>().SetTower(null);
            GameManager.Instance.clickb = true;
            GameManager.Instance.clickc = true;
            GameManager.Instance.clickd = true;
        }
    }

    public override void TowerBuilt()
    {
        if (TowerPanel != null && GameManager.Instance.clicka == true)
        {
            TowerPanel.GetComponent<UIController>().Show();
            TowerPanel.GetComponent<TowerTopController>().SetTower(this);
            GameManager.Instance.clickb = false;
            GameManager.Instance.clickc = false;
            GameManager.Instance.clickd = false;
        }
    }

    public GameObject TowerBuilt(GameObject _Tower)
    {
        Vector2 _ofset = new Vector2(transform.position.x,_Tower.transform.position.y);
        CloseTower();
        Destroy(gameObject);
        return Instantiate(_Tower, _ofset, Quaternion.identity, transform.parent);
    }
}
