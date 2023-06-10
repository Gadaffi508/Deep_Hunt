using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecendLevelSpawnPointScripts : MonoBehaviour
{
    public GameObject tankEnemy;
    public GameObject SmallEnemy;
    public GameObject DrunkEnemy;
    public GameObject GirdapEnemy;
    public GameObject FlyEnemy;
    public GameObject clambEnemy;


    private Vector2 SeaPoint;
    private Vector2 FlyPoint;
    private Vector2 DeepPoint;
    private Transform target;

    private void Start()
    {
        SpawnerTwo();
    }

    private void SpawnerTwo()
    {
        StartCoroutine(SpawnerTimer());
    }


    IEnumerator SpawnerTimer()
    {
        //Wave 1
        for (int i = 0; i < 3; i++)
        {
            int random1 = Random.Range(0, 2);
            int random2 = Random.Range(0, 2);
            if (random2 == 0)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                FlyPoint = new Vector2(target.position.x + 20f, 0);
                Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(4f);
            }
            else if (random2 == 1)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                FlyPoint = new Vector2(target.position.x - 20f, 0);
                Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(4f);
            }
            if (random1 == 0)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
            else if (random1 == 1)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x - 20f, -6.2f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
            for (int a = 0; a < 2; a++)
            {
                Instantiate(SmallEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                Instantiate(FlyEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
        }
        yield return new WaitForSeconds(16);
        //Wave 2
        for (int i = 0; i < 4; i++)
        {
            int random1 = Random.Range(0, 2);
            int random2 = Random.Range(0, 2);
            int number = 0;

            if (number < 4)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                DeepPoint = new Vector2(Random.Range(transform.position.x - 5, transform.position.x + 6), -15f);
                Instantiate(clambEnemy, DeepPoint, Quaternion.identity);
                number++;
            }
            if (random2 == 0)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                FlyPoint = new Vector2(target.position.x + 20f, 0);
                Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            else if (random2 == 1)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                FlyPoint = new Vector2(target.position.x - 20f, 0);
                Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            if (random1 == 0)
            {
                if (number < 1)
                {
                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                    Instantiate(GirdapEnemy, SeaPoint, Quaternion.identity);
                }
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            else if (random1 == 1)
            {
                if (number < 1)
                {
                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                    Instantiate(GirdapEnemy, SeaPoint, Quaternion.identity);
                }
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x - 20f, -6.2f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            for (int a = 0; a < 3; a++)
            {
                Instantiate(SmallEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                Instantiate(FlyEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);
            }
        }
        yield return new WaitForSeconds(20);
        //Wave3
        for (int i = 0; i < 4; i++)
        {
            int random1 = Random.Range(0, 2);
            int random2 = Random.Range(0, 2);
            int number = 0;

            if (number < 4)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                DeepPoint = new Vector2(Random.Range(transform.position.x - 5, transform.position.x + 6), -15f);
                Instantiate(clambEnemy, DeepPoint, Quaternion.identity);
                number++;
            }
                if (random2 == 0)
                {
                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    FlyPoint = new Vector2(target.position.x + 20f, 0);
                    Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                else if (random2 == 1)
                {

                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    FlyPoint = new Vector2(target.position.x - 20f, 0);
                    Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                if (random1 == 0)
                {
                    if (number < 1)
                    {
                        target = GameObject.FindGameObjectWithTag("Ship").transform;
                        SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                        Instantiate(GirdapEnemy, SeaPoint, Quaternion.identity);
                    }
                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                    Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                else if (random1 == 1)
                {
                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    SeaPoint = new Vector2(target.position.x - 20f, -6.2f);
                    Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                    yield return new WaitForSeconds(1f);
                }
                for (int a = 0; a < 2; a++)
                {
                    Instantiate(SmallEnemy, SeaPoint, Quaternion.identity);
                    yield return new WaitForSeconds(2);
                    Instantiate(FlyEnemy, FlyPoint, Quaternion.identity);
                    yield return new WaitForSeconds(1);
                }
        }
        yield return new WaitForSeconds(2);
        //Wave 4
        for (int i = 0; i < 5; i++)
        {
            int random1 = Random.Range(0, 2);
            int random2 = Random.Range(0, 2);
            int number = 0;

            if (number < 5)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                DeepPoint = new Vector2(Random.Range(transform.position.x - 5, transform.position.x + 6), -15f);
                Instantiate(clambEnemy, DeepPoint, Quaternion.identity);
                number++;
            }

            if (random2 == 0)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                FlyPoint = new Vector2(target.position.x + 20f, 0);
                Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            else if (random2 == 2)
            {

                target = GameObject.FindGameObjectWithTag("Ship").transform;
                FlyPoint = new Vector2(target.position.x - 20f, 0);
                Instantiate(DrunkEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            if (random1 == 0)
            {
                if (number < 2)
                {
                    target = GameObject.FindGameObjectWithTag("Ship").transform;
                    SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                    Instantiate(GirdapEnemy, SeaPoint, Quaternion.identity);
                }
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x + 20f, -6.2f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            else if (random1 == 1)
            {
                target = GameObject.FindGameObjectWithTag("Ship").transform;
                SeaPoint = new Vector2(target.position.x - 20f, -6.2f);
                Instantiate(tankEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            for (int a = 0; a < 2; a++)
            {
                Instantiate(SmallEnemy, SeaPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                Instantiate(FlyEnemy, FlyPoint, Quaternion.identity);
                yield return new WaitForSeconds(2f);

            }
        }


    }
}
