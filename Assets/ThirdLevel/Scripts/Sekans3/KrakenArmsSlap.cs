using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class KrakenArmsSlap : MonoBehaviour
{
    public GameObject Arm;
    private Transform ship;
    public Transform[] Points;
    public Transform[] Pointt;
    private Vector2 spawnPoint;
    public GameObject Warning;
    private Transform target;
    public void BossSekans2Calistir()
    {
        StartCoroutine(Timer());
    }
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship").transform;
    }
    private void ArmSpawner()
    {
        int random = Random.Range(0, Points.Length);
        GameObject warning = Instantiate(Warning, Points[random].position,Quaternion.identity);
        GameObject arm = Instantiate(Arm, Points[random].position,Quaternion.identity);
    }

    IEnumerator Timer()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        Vector2 newPoint1 = new Vector2(target.position.x + 5f, -6.3f);
        Vector2 newPoint2 = new Vector2(target.position.x + -5f,-6.3f);
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            GameObject warning = Instantiate(Warning, newPoint1, Quaternion.identity);
           
            yield return new WaitForSeconds(0.5f);
            warning.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            warning.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.5f);
            warning.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(1f);
          

            GameObject arm = Instantiate(Arm, newPoint1, Quaternion.identity);

        }
        else if (random == 1)
        {
            target = GameObject.FindGameObjectWithTag("Ship").transform;
            GameObject warning = Instantiate(Warning, newPoint2, Quaternion.identity);
          
            yield return new WaitForSeconds(0.5f);
            warning.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            warning.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.5f);
            warning.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(1f);
           
            GameObject arm = Instantiate(Arm, newPoint2, Quaternion.identity);

        }

    }
}
