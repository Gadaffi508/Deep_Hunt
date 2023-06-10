using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtomController : MonoBehaviour
{
    [SerializeField] BuiltTower[] allButtons;

    private TowerBottom currentArea;
    public TowerBottom SetTower(TowerBottom towerB) => currentArea = towerB;

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
        if (currentArea != null)
        {
            currentArea.TowerBuilt(_Tower);
        }
    }
}
