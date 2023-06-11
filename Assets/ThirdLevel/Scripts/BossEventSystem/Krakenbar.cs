using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Krakenbar : MonoBehaviour
{
    EnemyHealtAndAttackScripts enemy;
    public Image Healtbar;
    public GameObject HealtbarBG;

    public GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
        enemy = GetComponent<EnemyHealtAndAttackScripts>();
    }

    private void Update()
    {
        DamageFill();

        if (enemy.health <= 0)
        {
            panel.SetActive(true);
        }
    }
    public void DamageFill()
    {

        Healtbar.fillAmount = enemy.health / 4000;
    }

}
