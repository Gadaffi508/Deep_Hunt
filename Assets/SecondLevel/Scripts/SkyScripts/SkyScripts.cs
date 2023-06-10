using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScripts : MonoBehaviour
{
    public GameObject[] pufPrefabs;
    public GameObject[] pufPrefabs2;
    public Transform point;
    public float speed;
    void Start()
    {
        StartCoroutine(Timer());
    }

    
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        int random = Random.Range(0, pufPrefabs.Length);
        GameObject puf = Instantiate(pufPrefabs[random], point.position, Quaternion.identity);
        puf.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, 0f);
        yield return new WaitForSeconds(18f);
        StartCoroutine(Timer());
    }
}
