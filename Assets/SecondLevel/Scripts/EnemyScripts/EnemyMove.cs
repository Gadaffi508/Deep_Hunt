using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;


    [Header("Attribute")]
    [SerializeField] public float moveSpeed = 3f;
    float duration;


    public float prevMoveSpeed;
    public GameObject Effect;
    public Transform effectPoint;
    private EnemyHealtAndAttackScripts script;
    private Animator animator;

    private bool isFrozen = false; // Düþmanýn dondurulup dondurulmadýðýný takip etmek için bir flag
    private float freezeTimer = 0f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<EnemyHealtAndAttackScripts>();
        animator = GetComponent<Animator>();
    }
    public void Animation()
    {
        animator.SetBool("damage", false);
    }
    void Start()
    {
       
        animator.SetBool("touched", false);
       
        prevMoveSpeed = moveSpeed;
        if (transform.position.x > target.position.x)
        {
            moveSpeed *= -1;
            prevMoveSpeed *= -1;
            transform.localScale = new Vector3(1, 1, 1f);
        }
        if (transform.position.x < target.position.x)
        {
            moveSpeed *= 1;
            prevMoveSpeed *= 1;
            transform.localScale = new Vector3(-1, 1, 1f);
        }

    }
    private void Update()
    {

        Physics2D.queriesStartInColliders = true;

        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0f)
            {
                isFrozen = false;

                // Dondurma süresi sona erdiðinde yapýlmasý gereken iþlemler burada yer alabilir.
                moveSpeed = duration;
            }
        }


    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime,rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            animator.SetBool("damage", true);
            Instantiate(Effect, effectPoint.position, Quaternion.identity);

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            animator.SetBool("touched", true);
            moveSpeed = 0;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            animator.SetBool("touched", false);
            moveSpeed = prevMoveSpeed;
        }
    }
  
    public void Freeze(float duration)
    {
        if (!isFrozen)
        {
            isFrozen = true;
            freezeTimer = duration;

            // Dondurulduðunda yapýlmasý gereken iþlemler burada yer alabilir.
            moveSpeed = 0;
        }
    }


}
