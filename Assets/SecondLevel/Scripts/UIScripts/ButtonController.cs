using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Text ButtonName;
    public Text GunSpeed;
    public Text GunDamage;
    public Text GunName;

    public GameObject[] Ubg;

    [SerializeField] TopSelectButton[] allButtons;

    private ArcherTower currentTower;
    public ArcherTower SetTower(ArcherTower tower) => currentTower = tower;

    //Event Implements
    private void OnEnable()
    {
        foreach(var button in allButtons)
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
    private void ButtonClick(BulletScriptable bullet)
    {
        if(currentTower != null)
        {
           currentTower.Bullet = bullet;
        }
        for (int i = 0; i < Ubg.Length; i++)
        {
            Ubg[i].transform.DOMoveY(1500, 1);
        }
    }
}
