using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTutorial : MonoBehaviour
{
    public GameObject Fog;

    Transform targetPos;
    public Transform Target { get { return targetPos; } set 
        { 
            targetPos = value;

            if(targetPos != null)
                delayAmount = transform.position - targetPos.position;
        } 
    }

    public float speed = 2.0f;
    public Vector3 delayAmount;
    private Vector3 targetVector;
    public bool camM = true;

    public static CameraTutorial CamÝnstanceTut;

    private void Awake()
    {
        if (camM)
        {
            if (CamÝnstanceTut != null)
            {
                Destroy(this.gameObject);
                return;
            }
            CamÝnstanceTut = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        Fog.transform.DOMoveY(20, 1);
        
    }

    public void FollowShip()
    {
        StartCoroutine(loadFollow());
    }

    IEnumerator loadFollow()
    {
        yield return new WaitForSeconds(1);
        targetPos = GameObject.FindGameObjectWithTag("Ship").transform;
        // Karakter ile kamera arasýndaki baþlangýç mesafesini belirlemek için kullanýlýr.
        
    }

    void LateUpdate()
    {
        if (targetPos != null)
            targetVector = targetPos.position + delayAmount;

        Vector3 yumusatilmisPozisyon = Vector3.Lerp(transform.position, targetVector, speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(yumusatilmisPozisyon.x, -9, 8);

        yumusatilmisPozisyon = new Vector3(clampedX, transform.position.y, transform.position.z);

        transform.position = yumusatilmisPozisyon;


    }
}
