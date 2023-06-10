using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTopController : MonoBehaviour
{
    [SerializeField] BuiltTower[] allButtons;

    private TowerUp currentAreaU;
    public TowerUp SetTower(TowerUp towerU) => currentAreaU = towerU;

    //Event Implements
    private void OnEnable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonClick += ButtonClick;
        }
    }
    private void OnDisable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonClick -= ButtonClick;
        }
    }
    private void ButtonClick(GameObject _Tower)
    {
        if (currentAreaU != null)
        {
            currentAreaU.TowerBuilt(_Tower);
        }
    }
}
