using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrunkBirdEnemy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject hitObject;
    [SerializeField] private GameObject effect;
    [SerializeField] private Transform effectpoint;

    [Header("Attribute")]
    [SerializeField] private float AttackDistance = 15f;
    [SerializeField] private float MoveSpeed = 75f;
    [SerializeField] private float Force = 100f;

    private float randomMove;
    private Vector2 shipPosition;
    private Vector2 tansformPosition;
    private float Distance;
    private EnemyHealtAndAttackScripts script;
    private Animator animator;
    private Transform target;
    private AudioSource audio;
    public AudioClip blopSea;
    public AudioClip kanatSesi;
    
    
    public float attack;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        script = GetComponent<EnemyHealtAndAttackScripts>();
        animator = GetComponent<Animator>();
       
    }

    
    void FixedUpdate()
    {
        
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        Move();
        RaycastHit2D hit = Physics2D.Raycast(hitObject.transform.position,Vector2.down,AttackDistance);

        if (hit.collider == null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }
        else if (hit.collider.CompareTag("Ship"))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            
            Invoke("Attack", 0.3f);
            animator.SetBool("okey",true);
            animator.SetTrigger("touched");
            MoveSpeed = 0f;
        }
        else if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
    }
    //public float speed = 0.2f;
    //public float amplitude = 0.5f;
    //public float frequency = 0.1f;
    private void Update()
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {

                transform.localScale = new Vector3(1, 1, 1f);
            }
            else
            {

                transform.localScale = new Vector3(-1, 1, 1f);
            }
        }
    }
    private void Move()
    {

       

        //Vector3 direction = (target.position - transform.position).normalized;
        //transform.position += direction * speed * Time.deltaTime;

        //float y = Mathf.Sin(Time.time * frequency) * amplitude;
        //transform.position += new Vector3(0, y, 0);

        Distance = Vector2.Distance(transform.position, tansformPosition);
        if (Distance <= 0)
        {
            randomMove = Random.Range(1f, 4f);
        }
        tansformPosition = new Vector2(transform.position.x, randomMove);
        shipPosition = new Vector2(target.position.x, randomMove);
        transform.position = Vector2.MoveTowards(transform.position, shipPosition, MoveSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, tansformPosition, MoveSpeed * Time.deltaTime);
    }
    public void Animation()
    {
        animator.SetBool("damage", false);
    }
    private void Attack()
    {
        
        rb.velocity = new Vector2(rb.velocity.x,-Force * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            GameManager.Instance.TakeDamage(attack);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Arrow"))
        {
            animator.SetBool("damage",true);
            Instantiate(effect, effectpoint.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Sea"))
        {
            audio.PlayOneShot(blopSea);
            Destroy(gameObject,1f);
        }
    }


   
}
