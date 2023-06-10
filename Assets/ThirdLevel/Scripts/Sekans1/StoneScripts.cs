using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScripts : MonoBehaviour
{

    public float attack;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            GameManager.Instance.TakeDamage(attack);
        }
    }
}
