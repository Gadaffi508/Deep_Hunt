using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrekenScripts : MonoBehaviour
{
    [Header("Referances")]
    [SerializeField] private Transform target;
    [SerializeField] private GameObject arm;
    [SerializeField] private CrekenArmScripts crekenArmScripts;

    private float randomX;
    private Vector2 randomPosition;
    private bool isSpawn;
   
    void Start()
    {
        
        StartCoroutine(KrekenAttackTimer());

    }


    void Update()
    {
        
    }

    public void RandomSpawn()
    {
        randomX = Random.Range(target.position.x - 10f, target.position.x + 10f);
        if (randomX < target.position.x + 5f && randomX > target.position.x - 5f)
        {
            randomX = Random.Range(target.position.x - 10f, target.position.x + 10f);
        }
        randomPosition = new Vector2(randomX, -10f);
        Instantiate(arm, randomPosition, Quaternion.identity);
        isSpawn = true;
       
    }


    IEnumerator KrekenAttackTimer()
    {
        RandomSpawn();
        yield return new WaitForSeconds(5f);
        StartCoroutine(KrekenAttackTimer());
    }
}