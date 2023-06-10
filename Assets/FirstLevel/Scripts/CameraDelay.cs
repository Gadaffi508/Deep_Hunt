using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraDelay : MonoBehaviour
{
    public GameObject[] targetAll;
    public int level = 1;
    Transform targetPos;
    public float speed = 2.0f;
    public Vector3 delayAmount;
    private Vector3 targetVector;
    public static CameraDelay instance;
    public GameObject Fog;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartScene());
    }

    public IEnumerator StartScene()
    {
        for (int i = level + 1; i < targetAll.Length; i++)
        {
            targetAll[i].SetActive(false);
            targetAll[level].SetActive(true);
        }

        if(level > 1)
            targetPos = targetAll[level-1].transform;
        else
            targetPos = targetAll[1].transform;


        yield return new WaitForSeconds(1);
        delayAmount = transform.position - targetPos.position;

        targetPos = targetAll[level].transform;
    }

    void LateUpdate()
    {
        if (targetPos != null)
            targetVector = targetPos.position + delayAmount;

        Vector3 yumusatilmisPozisyon = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);

        transform.position = yumusatilmisPozisyon;

        Mathf.Clamp(transform.position.y, -9.66f, 9.77f);
    }
    public void FogOut()
    {
        Fog.transform.DOMoveY(-5, 2);
    }
}
