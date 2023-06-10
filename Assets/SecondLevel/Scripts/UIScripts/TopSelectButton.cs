using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopSelectButton : MonoBehaviour
{
    public BulletScriptable bullet;
    public Image BulletSprite;

    //Events
    public event Action<BulletScriptable> OnButtonClick;

    //private variables
    private Button button;
    TowerS towerGold;

    private void Start()
    {
        towerGold = GetComponent<TowerS>();

        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);

        BulletSprite.sprite = bullet.spt.sprite;
    }
    //Mouse on click
    public void OnClick()
    {
        if (GameManager.Instance.Gold >= towerGold.buyTower)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(bullet);
                GameManager.Instance.built = true;
            }
            towerGold.BuyTower();
        }
        else
        {
            Debug.Log("No money");
        }
    }
}
