using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private EnemyMove enemyMove;
 

    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float bps = 1f;//bullet per second

    private Transform target;
    private float timeUntilFire;
    private Transform ship;
    private Animator animator;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyMove = GetComponent<EnemyMove>();
        
        
        
    }
    void Update()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
        if (transform.position.x > ship.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            enemyMove.moveSpeed = -100;
        }
        else if (transform.position.x < ship.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            enemyMove.moveSpeed = 100f;
        }
        Physics2D.queriesStartInColliders = true;
        if (target == null)
        {
            FindTarget();
            return;
        }
       
        if (!CheckTargetInRange())
        {
            target = null;
            enemyMove.moveSpeed = enemyMove.prevMoveSpeed;
            animator.SetBool("touched", false);
            if (transform.position.x > ship.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                enemyMove.moveSpeed = -100;
            }
            else if (transform.position.x < ship.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                enemyMove.moveSpeed = 100f;
            }
        }
        else
        {
            enemyMove.moveSpeed = 0f;
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                animator.SetBool("touched", true);
                timeUntilFire = 0f;
            }
        }

    }
    private void Shoot()
    {
        GameObject row = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        FlyEnemyBullet arrowScripts = row.GetComponent<FlyEnemyBullet>();
        arrowScripts.SetTarget(target);

    }
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= attackRange;
    }
  
   
}


