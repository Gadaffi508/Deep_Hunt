using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherUpTower : MonoBehaviour
{
    [Header("Upgrade Tower")]
    [SerializeField] GameObject upgradeTower;
    [Space]
    BoatController boat;
    private void Start()
    {
        boat = GameObject.FindGameObjectWithTag("Ship").gameObject.GetComponent<BoatController>();
    }

    private void Update()
    {
        if (boat.isFacingRight)
        {
            transform.localScale = new Vector2(.5f, .5f);
        }
        else
        {
            transform.localScale = new Vector2(-.5f, .5f);
        }

    }
    public void UpgradeTowerButton()
    {
        Destroy(gameObject);
        Instantiate(upgradeTower, transform.position, Quaternion.identity);
        GetComponentInChildren<Try>().CloseTower();
    }
    public void HealthUpgrade()
    {
        if (GameManager.Instance.Health < 100)
        {
            GameManager.Instance.Heal(0.55f);
        }
    }
    public void DamageDecrease()
    {
        GameManager.Instance.damagedecrease = 5;
    }
}
