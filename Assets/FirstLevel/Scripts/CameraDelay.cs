using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraDelay : MonoBehaviour
{
    public GameObject[] targetAll;
    Transform targetPos;
    public float speed = 2.0f;
    public Vector3 delayAmount;
    private Vector3 targetVector;
    public static CameraDelay instance;
    public GameObject Fog;
    public int level;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartScene());
        //level = LevelManager.instanceLevel.levelM;
    }

    public IEnumerator StartScene()
    {
        targetPos = targetAll[level].transform;
        yield return new WaitForSeconds(1);
        level = LevelManager.instanceLevel.levelM;
        if (level == 1)
        {
            targetAll[2].SetActive(false);
            targetAll[3].SetActive(false);
            targetPos = targetAll[1].transform;
            level = 1;

        }
        if(level == 2)
        {
            targetAll[2].SetActive(true);
            targetAll[3].SetActive(false);
            targetPos = targetAll[2].transform;
            level = 2;
        }
        if (level == 3)
        {
            targetAll[3].SetActive(true);
            targetPos = targetAll[3].transform;
            level=3;
        }

        for (int i = level + 1; i < targetAll.Length; i++)
        {
            targetAll[i].SetActive(false);
        }

    }

    void LateUpdate()
    {
        if (targetPos != null)
            targetVector = targetPos.position + delayAmount;

        Vector3 yumusatilmisPozisyon = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);

        transform.position = new Vector3(yumusatilmisPozisyon.x, yumusatilmisPozisyon.y, -10);

        Mathf.Clamp(transform.position.y, -9.66f, 9.77f);
    }
    public void FogOut()
    {
        Fog.transform.DOMoveY(-5, 2);
    }
}
