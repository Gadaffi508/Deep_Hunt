using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStan : ArrowScripts
{
    public float explosionRadius = 2f; // Patlama alanýnýn yarýçapý
    public float freezeDuration = 1f; // Düþmanlarýn donma süresi

    public override void EnemyAttack(Collision2D collision)
    {
        // Düþmanlarý dondurmak için bir alan oluþtur
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Düþmaný dondurmak için özel bir script çaðýr
                EnemyMove enemyController = enemy.GetComponent<EnemyMove>();
                if (enemyController != null)
                {
                    enemyController.Freeze(freezeDuration);
                }

                EnemyHealtAndAttackScripts enemyHealth = enemy.GetComponent<EnemyHealtAndAttackScripts>();
                if (enemyHealth != null)
                {
                    enemyHealth.DamageHealth(Damage);
                }
            }
        }
    }

    public override void EnemyAttack(Collider2D collision)
    {
        // Düþmanlarý dondurmak için bir alan oluþtur
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Düþmaný dondurmak için özel bir script çaðýr
                EnemyMove enemyController = enemy.GetComponent<EnemyMove>();
                if (enemyController != null)
                {
                    enemyController.Freeze(freezeDuration);
                }

                EnemyHealtAndAttackScripts enemyHealth = enemy.GetComponent<EnemyHealtAndAttackScripts>();
                if (enemyHealth != null)
                {
                    enemyHealth.DamageHealth(Damage);
                }
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        // Patlama alanýný görselleþtirmek için Gizmos kullan
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
