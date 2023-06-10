using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Krakenbar : MonoBehaviour
{
    EnemyHealtAndAttackScripts enemy;
    public Image Healtbar;
    public GameObject HealtbarBG;

    private void Start()
    {
        enemy = GetComponent<EnemyHealtAndAttackScripts>();
    }

    public void DamageFill()
    {

        Healtbar.fillAmount = enemy.health / 1300;
    }

}
