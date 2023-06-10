using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAndSlowHealth : MonoBehaviour
{
    public Vector2 size = new Vector2(1f, 1f); // Saldýrý alanýnýn boyutu
    public int damageAmount = 10; // Zarar miktarý
    public LayerMask enemyLayer; // Düþmanlarýn bulunduðu katman
    public float rotationSpeed = 20;
    public float nextPrefab;

    private void FixedUpdate()
    {
        if (transform.parent.transform.localScale.x >= 1)
        {
            rotationSpeed = 20;
        }
        else
        {
            rotationSpeed = -20;
        }

        nextPrefab += Time.deltaTime;
        if (nextPrefab >= .5f)
        {
            StartCoroutine(Attack());
            nextPrefab = 0;

        }
    }

    IEnumerator Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, size, 0f, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealtAndAttackScripts enemyHealth = enemy.GetComponent<EnemyHealtAndAttackScripts>();
            if (enemyHealth != null)
            {
                enemyHealth.DamageHealth(damageAmount);
                enemyHealth.attack = 3;
            }
        }

        yield return new WaitForSeconds(1);
        // OverlapBoxAll dýþýndayken, enemyHealth.behind = false yapýlabilir
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != null)
            {
                EnemyHealtAndAttackScripts enemyHealth = enemy.GetComponent<EnemyHealtAndAttackScripts>();
                if (enemyHealth != null)
                {
                    enemyHealth.attack = 8;
                }
            }
          
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;

        // Gizmo'yu döndürmek için dönme açýsýný güncelle
        rotation = Quaternion.Euler(0f, 0f, rotationSpeed);

        // Dikdörtgenin dönme açýsýný uygula
        Gizmos.matrix = Matrix4x4.TRS(position, rotation, Vector3.one);

        Gizmos.DrawWireCube(Vector3.zero, size);
    }
}
