using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DrunkEnemyBoosVersion : MonoBehaviour
{
    private Animator m_Animator;

    public float attack;
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        transform.DOMoveY(transform.position.y - 3f, 2f).OnComplete(() =>
        {
            m_Animator.SetBool("okey",true);
            transform.DOMoveY(transform.position.y, 3f).OnComplete(() =>
            {
                m_Animator.SetTrigger("touched");
                transform.DOMoveY(transform.position.y - 32f, 3f).OnComplete(() =>
                {
                    Destroy(gameObject);
                });
            });
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            GameManager.Instance.TakeDamage(attack);
        }
    }
}
