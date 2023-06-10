using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class İmagaScript : MonoBehaviour
{
    public Image enemy;
    void Start()
    {
        enemy.GetComponent<Image>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            enemy.enabled = true;
        }
        else
        {
            enemy.enabled=false;
        }
    }

    

}
