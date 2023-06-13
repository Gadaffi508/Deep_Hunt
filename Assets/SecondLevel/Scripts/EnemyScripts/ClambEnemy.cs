using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ClambEnemy : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private float speed;
    [SerializeField] private float maxHeight = -5.5f;
    [Space]
    [SerializeField] private int damage;

    private Animator animator;
    private Rigidbody2D rb;

    private AudioSource audioSource;
    public AudioClip ses;
    int hurt = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Timer());
    }

    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        if (transform.position.y < maxHeight)
        {
            rb.velocity = -Vector2.down * speed;
        }
    }

    public void OnTrigger(BoatController boat)
    {
        //Set Damage
        animator.SetBool("isCollision",true);
        StartCoroutine(DamageShip());

        //SetParent
        transform.SetParent(boat.gameObject.transform);

        //Set Static
        rb.bodyType = RigidbodyType2D.Kinematic;
        speed = 0;

        //Destroy(this,1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            hurt++;
            Destroy(collision.gameObject);
            if (hurt > 0)
            {
                animator.SetBool("death", true);

                Destroy(gameObject);
            }
        }
    }

    IEnumerator DamageShip()
    {
        yield return new WaitForSeconds(0.75f);
        damage += 2;
        GameManager.Instance.TakeDamage(damage);

        audioSource.PlayOneShot(ses);
        StartCoroutine(DamageShip());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(Timer());
    }
}
