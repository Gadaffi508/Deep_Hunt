using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class WhirlpoolEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private LayerMask shipLayer;
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject effect1;
    [SerializeField] private Transform pointEffect;
    [SerializeField] private Transform pointEffect1;

    [Header("Attribute")]
    [SerializeField] private float attackRange = 15f;
    [SerializeField] private float Force;
    [SerializeField] private float Speed;

    private Rigidbody2D rb;
    private Transform target;
    private Animator animator;
    private AudioSource audio;
    public AudioClip blob;
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1f);
        }
    }
  
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1f);
            rb.velocity = new Vector2(-Speed * Time.deltaTime, rb.velocity.y);
        }
        else if (transform.position.x < target.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1f);
            rb.velocity = new Vector2(Speed * Time.deltaTime, rb.velocity.y);
        }
        RaycastHit2D hits = Physics2D.CircleCast(transform.position, attackRange, (Vector2)transform.position, 0f, shipLayer);

        if (hits)
        {
            
            transform.DOMoveY(-7.5f, 1).OnComplete(() =>
            {
               
                Speed = 0;
               
                Whirlpool();
            });
        }
        else 
        {
            animator.SetBool("touched", false);
            transform.DOMoveY(-5.2f, 1).OnComplete(() =>
            {
                Speed = 75;
            });
           
        }
    }
    public void Animation()
    {
        animator.SetBool("damage", false);
    }

    private void Whirlpool()
    {
        Instantiate(effect,pointEffect.position,Quaternion.identity);
        
        if (transform.position.x > target.position.x)
        {
            target.transform.Translate(Force,0,0);
            animator.SetBool("touched",true);
        }
        else if (transform.position.x < target.position.x)
        {
            target.transform.Translate(-Force, 0, 0);
           
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            animator.SetBool("damage", true);
            Instantiate(effect1, pointEffect1.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Sea"))
        {
            audio.PlayOneShot(blob);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sea"))
        {
            audio.PlayOneShot(blob);
        }
    }



}
