using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenArmRock : MonoBehaviour
{
    public GameObject stone;
    private Transform target;
    public Transform rockPoint;
    public float Force,force;
    public float attack;

    void Start()
    {
       
       target = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > target.position.x)
        {
            force *= -1;
            transform.localScale = new Vector3(2,3,1);
        }
        else if (transform.position.x < target.position.x)
        {
            force *= 1;
            transform.localScale = new Vector3(-2, 3, 1);
        }
    }
    public void AttackOne()
    {
        GameObject rockIns = Instantiate(stone, rockPoint.position, Quaternion.identity);
        rockIns.GetComponent<Rigidbody2D>().AddForce(transform.up * Force);
        rockIns.GetComponent<Rigidbody2D>().AddForce(Vector2.left * -force);
        Destroy(rockIns, 3f);
    }
  

}
