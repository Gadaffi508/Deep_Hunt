using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuiltTower : MonoBehaviour
{
    public GameObject towerP;
    public Sprite TowerRenderer;
    public Image TowerSprite;
    public Text �nformat�on;

    //Events
    public event Action<GameObject> OnButtonClick;

    //private variables
    private Button button;
    TowerS towerGold;

    private void Start()
    {
        if (GameManager.Instance.�nformato�nTower != null)
        {
            //�nformat�on.text = GameManager.Instance.�nformato�nTower; bo�ver silecem
        }

        towerGold = GetComponent<TowerS>();

        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);

        TowerSprite.sprite = TowerRenderer;
    }
    //Mouse on click
    public void OnClick()
    {
        if (GameManager.Instance.Gold >= towerGold.buyTower)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(towerP);
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
