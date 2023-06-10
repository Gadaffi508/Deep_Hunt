using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenEnemySpawner : MonoBehaviour
{
    public GameObject tankEnemy;
    public GameObject normalEnemy;

    public Transform[] points;

    public int numberOfWave;

    public int normalEnemyNumber;
    void Start()
    {
        
    }
    public void EnemySpawner()
    {
        StartCoroutine(SpawnerTimer());
    }
    IEnumerator SpawnerTimer()
    {
        for (int i = 0; i < 2; i++)
        {
            int random = Random.Range(0, points.Length);
            Instantiate(tankEnemy, points[random].position,Quaternion.identity);
            yield return new WaitForSeconds(3f);
            for (int a = 0; a < 2; a++)
            {
                Instantiate(normalEnemy, points[random].position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
        }
    }
   
}
