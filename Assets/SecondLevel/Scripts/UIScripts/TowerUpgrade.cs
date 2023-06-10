using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    public event Action OnButtonClick;
    TowerS buyT;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        buyT = GetComponent<TowerS>();
    }

    public void OnClick()
    {
        if (GameManager.Instance.Gold >= buyT.buyTower)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick();
            }
        buyT.BuyTower();
        }
        else
        {
            Debug.Log("No money");
        }
    }
}
