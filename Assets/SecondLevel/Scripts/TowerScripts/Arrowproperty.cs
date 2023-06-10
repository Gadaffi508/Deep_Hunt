using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrowproperty : ArrowScripts
{
    public override void EnemyAttack(Collision2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().DamageHealth(Damage);
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarVeriliyor = true;
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarSure = 5;
    }

    public override void EnemyAttack(Collider2D collision)
    {
        Destroy(gameObject);
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().DamageHealth(Damage);
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarVeriliyor = true;
        collision.gameObject.GetComponent<EnemyHealtAndAttackScripts>().hasarSure = 5;
    }

  
}
