using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneFall : MonoBehaviour
{
    public GameObject stonePrefaps, warning;
    private Transform target;
    Vector2 warningPos;
    Vector2 warningPos2;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ship").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            warningPos = new Vector2(target.position.x,8.5f);
            warningPos2 = new Vector2(target.position.x, 9f);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        GameObject warningIns = Instantiate(warning,warningPos,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        warningIns.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1f);
        warningIns.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        Destroy(warningIns);
        GameObject stoneIns = Instantiate(stonePrefaps, warningPos2, Quaternion.identity);
        stoneIns.GetComponent<Rigidbody2D>().gravityScale = 2f;
    }
}
