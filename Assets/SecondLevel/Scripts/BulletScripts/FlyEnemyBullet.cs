using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyBullet : MonoBehaviour
{
    private Transform target;
    private float rowSpeed = 6f;
    private EnemyHealtAndAttackScripts scripts;
    public int damage;
    public float attack;

    void Start()
    {
        scripts = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealtAndAttackScripts>();
        Destroy(gameObject, 1.5f);
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, rowSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            GameManager.Instance.TakeDamage(damage);
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag("kuleA"))
        {
            GameManager.Instance.TakeDamage(damage);
            Destroy(gameObject);    

        }
    }

   
}
