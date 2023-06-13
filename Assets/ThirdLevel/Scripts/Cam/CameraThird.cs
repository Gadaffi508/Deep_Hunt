using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraThird : MonoBehaviour
{
    private bool titremeDevamEdiyor = false;
    private Vector3 orijinalPozisyon;
    private float titremeSiddeti = 0.1f;
    private float titremeSure = 1f;

    public static CameraThird instance;

    private void Awake()
    {
        instance = this;
    }

    public void BaslatTitreme()
    {
        if (!titremeDevamEdiyor)
        {
            orijinalPozisyon = transform.position;
            titremeDevamEdiyor = true;
            InvokeRepeating("TitremeEfekti", 0f, 0.01f);
            Invoke("DurdurTitreme", titremeSure);
        }
    }

    void TitremeEfekti()
    {
        float titremeX = Random.Range(-titremeSiddeti, titremeSiddeti);
        float titremeY = Random.Range(-titremeSiddeti, titremeSiddeti);
        float titremeZ = Random.Range(-titremeSiddeti, titremeSiddeti);

        transform.position = new Vector3(orijinalPozisyon.x + titremeX, orijinalPozisyon.y + titremeY, orijinalPozisyon.z + titremeZ);
    }

    void DurdurTitreme()
    {
        titremeDevamEdiyor = false;
        CancelInvoke("TitremeEfekti");
        transform.position = orijinalPozisyon;
    }

}
