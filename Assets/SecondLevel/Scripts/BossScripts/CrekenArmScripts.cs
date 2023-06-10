using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrekenArmScripts : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject EnemyPrefabs;

    [Header("Attribute")]
    [SerializeField] private float upForce;
    [SerializeField] private float bps = 1f;//bullet per second

    private Vector2 shýpPosition;
    private float timeUntilFire;
    public static bool attacked = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (attacked)
            UpForce();
        if (attacked == false)
        {
            DownForce();
        }
    }
    public void UpForce()
    {
       
            rb.velocity = new Vector2(rb.velocity.x, upForce);
            if (transform.position.y >= -3f)
            {
                rb.velocity = Vector2.zero;
                Attack();
            
        }
    }
    public void DownForce()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, -upForce);
        
        if (transform.position.y <= -10f)
        {
            attacked = true;
            Destroy(gameObject);
        }
    }
    public void Attack()
    {
        Vector2 targetPos = target.position;
        shýpPosition = targetPos - (Vector2)transform.position;
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / bps)
        {
          
            GameObject enemyIns = Instantiate(EnemyPrefabs, attackPoint.position, Quaternion.identity);
            enemyIns.GetComponent<Rigidbody2D>().AddForce(shýpPosition * 100f);
            timeUntilFire = 0f;
            attacked = false;
        }
    }
}
