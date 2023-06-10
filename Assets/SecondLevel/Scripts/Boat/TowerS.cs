using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerS : MonoBehaviour
{
    public int buyTower;
    public void BuyTower()
    {
        GameManager.Instance.Gold -= buyTower;
    }
}
