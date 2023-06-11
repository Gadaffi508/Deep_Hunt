using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryUp : BoatTowerController
{
    private ArcherUpTower tower;

    [Header("Text")]
    public GameObject gunInfoPanel;
    public GameObject TowerUpgrade;
    public bool upgrade = false;
    private AudioSource audio;
    public AudioClip[] takTak;
    
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        tower = transform.GetComponentInParent<ArcherUpTower>();
        TowerUpgrade = GameObject.FindGameObjectWithTag("PanelFive").gameObject;        
    }
    public void Music(int number)
    {
        audio.PlayOneShot(takTak[number]);
        number++;
        if (number == takTak.Length)
        {
            number = 0;
        }
    }
    public override void CloseTower()
    {
        TowerUpgrade.GetComponent<UIController>().Hide();
    }

    public override void TowerBuilt()
    {
        if (TowerUpgrade != null && upgrade == true)
        {
            TowerUpgrade.GetComponent<UIController>().Show();
        }
    }
    public void HealthUpgrade()
    {
        tower.HealthUpgrade();
    }
    public void DamageDecrease()
    {
        tower.DamageDecrease();
    }
}
