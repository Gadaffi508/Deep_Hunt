using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomberEnemy : MonoBehaviour
{
    [Header("Referemces")]
    [SerializeField] private LayerMask objectOfInfluence;
    [SerializeField] private GameObject enemyPrefabs;

    [Header("Attribute")]
    [SerializeField] private float fieldOfImpact;
    [SerializeField] private float force;

    private EnemyMove enemyMove;
    private bool isExplod;
    private bool isDead;
    private void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
    }
    private void Explode()
    {
        Collider2D[] onject = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, objectOfInfluence);

        foreach(Collider2D obj in onject)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        for (int i = 0; i < 5; i++)
        {
            float randomNum = Random.Range(-50,100);
            GameObject enemy =  Instantiate(enemyPrefabs,transform.position,Quaternion.identity);
            enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * randomNum);

        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if (isDead)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(enemyPrefabs, transform.position, Quaternion.identity);
            }
        }
    }
    private void FixedUpdate()
    {
        if (isExplod)
            Explode();

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position,fieldOfImpact);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            isExplod = true;
            enemyMove.moveSpeed = 0;
          
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            isExplod = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            isDead = true;
            if (isDead)
            {
                for (int i = 0; i < 5; i++)
                {
                    float randomNum = Random.Range(-50, 100);
                    GameObject enemy = Instantiate(enemyPrefabs, transform.position, Quaternion.identity);
                    enemy.GetComponent<Rigidbody2D>().AddForce(Vector2.left * randomNum);
                }
            }
            Destroy(gameObject);
        }
    }
}
