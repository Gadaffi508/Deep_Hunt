using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEnemy : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;


    [Header("Attribute")]
    [SerializeField] public float moveSpeed = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (transform.position.x > target.position.x)
        {
            moveSpeed *= -1;
            transform.localScale = new Vector3(1, 1, 1f);
        }
        else
        {
            moveSpeed *= 1;
            transform.localScale = new Vector3(-1, 1, 1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.left * -moveSpeed * Time.deltaTime);
    }


}
