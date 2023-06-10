using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrownormal : ArrowScripts
{
    public override void EnemyAttack(Collision2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().DamageHealth(Damage);
    }

    public override void EnemyAttack(Collider2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().DamageHealth(Damage);
    }
}
