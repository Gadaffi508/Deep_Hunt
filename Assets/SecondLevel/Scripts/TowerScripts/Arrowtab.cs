using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrowtab : ArrowScripts
{
    public Transform[] hedefler; // Hedef noktalarý dizisi
    public int targetnow = 0;

    public override void EnemyAttack(Collision2D collision)
    {
        target = FindEnemyDistance();
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().DamageHealth(Damage);
    }

    public override void EnemyAttack(Collider2D collision)
    {
        target = FindEnemyDistance();
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().DamageHealth(Damage);
    }

    private Transform FindEnemyDistance()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (targetnow + 1 >= 1 || enemys[targetnow + 1] == null)
        {
            targetnow = 0;
        }
        else
        {
            targetnow++;
        }

        return enemys[targetnow].transform;

    }
}
