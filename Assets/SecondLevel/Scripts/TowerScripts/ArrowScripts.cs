using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArrowScripts : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;

    [Header("Attributes")]
    public float rowSpeed = 5f;
    public int Damage;
    public string Name;

    public Transform target;
    private void Start()
    {
        Damage = 15;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void FixedUpdate()
    {
        if (target)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.position, rowSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAttack(collision);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyAttack(collision);
        }
    }

    public abstract void EnemyAttack(Collision2D collision);
    public abstract void EnemyAttack(Collider2D collision);
}
