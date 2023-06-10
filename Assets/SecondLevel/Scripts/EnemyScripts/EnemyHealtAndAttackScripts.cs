using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealtAndAttackScripts : MonoBehaviour
{
    [Header("Healt")]
    [SerializeField] public float health;
    [Header("Attack")]
    [SerializeField] public int attack;

    private Animator animator;
    public GameObject puffEffect;
    public Transform effectPoint1;
    SpriteRenderer render;
    private EnemyMove move;

    public float hasarSure = 5f; // Hasar süresi (saniye)
    private float hasarPerSaniye = 1f; // Saniyede verilen hasar miktarý
    public bool hasarVeriliyor = false;
    private AudioSource audio;
    public AudioClip deadSound;

    void Start()
    {
        move = GetComponent<EnemyMove>();
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        render.enabled = true;
        audio = GetComponent<AudioSource>();
    }
    public void TakeDamage()
    {
        GameManager.Instance.TakeDamage(attack);

    }

    IEnumerator Timer()
    {
        //animator.SetBool("Dead", true);
        //move.moveSpeed = 0;
        yield return new WaitForSeconds(0.5f);
        render.enabled = false;
        //audio.PlayOneShot(deadSound);
        Instantiate(puffEffect, effectPoint1.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (hasarVeriliyor && health > 0) // Hasar veriliyorsa ve düþman ölmediyse
        {
            hasarSure -= Time.deltaTime; // Zamaný güncelle
            if (hasarSure <= 0) // Hasar süresi tamamlandýysa
            {
                hasarVeriliyor = false; // Hasar verme durdurulur
            }
            else
            {
                DamageHealth(hasarPerSaniye * Time.deltaTime); // Hasarý uygula
            }
        }

        
    }

    public void DamageHealth(float hasar)
    {
        health -=hasar;
        if (health <= 0)
        {
            GameManager.Instance.Gold += 3;
            StartCoroutine(Timer());
        }
    }
}
