using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DrunkSpawn : MonoBehaviour
{
    public Transform[] point;
    public GameObject pointObject;
    public GameObject Enemy;
    private Transform target;
    private Animator animator;
    private CameraThird camera;
    void Start()
    {
       
        target = GameObject.FindGameObjectWithTag("Ship").transform;
        animator = GetComponent<Animator>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraThird>();
    }

    void BossSekans3Calistir()
    {
        animator.SetBool("krakenScream", true);
        
        DrunkEnemySpawn();
    }

   public void ChangePoint()
    {
        pointObject.transform.position = new Vector2(target.position.x, 12);
    }

    public void DrunkEnemySpawn()
    {
        ChangePoint();
        for (int i = 0; i < point.Length; i++)
        {
            GameObject enemy = Instantiate(Enemy, point[i].position,Quaternion.identity); 
        }

       
    }

   
}
