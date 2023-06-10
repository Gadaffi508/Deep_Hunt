using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelsBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    ArcherTower archerTower;
    public Transform target;
    Vector2 direction;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        archerTower = GameObject.FindGameObjectWithTag("kuleA").gameObject.GetComponent<ArcherTower>();

    }
    private void FixedUpdate()
    {
        Vector2 newPos = target.position;
        direction = (Vector2)transform.position -newPos;
        rb.AddForce(Vector2.left * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            StartCoroutine(Timer());
            Destroy(gameObject);
        }
    }

    IEnumerator Timer()
    {
        //archerTower.bps = 0;
        yield return new WaitForSeconds(0.5f);
        //archerTower.bps = 1;
    }
}
