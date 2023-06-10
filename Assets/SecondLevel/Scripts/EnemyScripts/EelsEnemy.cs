using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EelsEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Transform target;
    [SerializeField] private LayerMask shipLayer;
    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform attackPoint;


    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float Speed;
    [SerializeField] private float bps = 1f;//bullet per second

    private Rigidbody2D rb;
    private float timeUntilFire;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x > target.position.x)
        {
            rb.velocity = new Vector2(-Speed * Time.deltaTime, rb.velocity.y);
        }
        else if (transform.position.x < target.position.x)
        {
            rb.velocity = new Vector2(Speed * Time.deltaTime, rb.velocity.y);
        }
        RaycastHit2D hits = Physics2D.CircleCast(transform.position, attackRange, (Vector2)transform.position, 0f, shipLayer);

        if (hits)
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                Attack();
                timeUntilFire = 0f;
            }
            Speed = 0;
        }
        else
        {
            Speed = 150f;
        }
       
    }

    private void Attack()
    {
        Instantiate(Bullet, attackPoint.position, Quaternion.identity);
    }
}
