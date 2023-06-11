using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFog : MonoBehaviour
{
    [SerializeField] Camera cam;
    SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x, Camera.main.orthographicSize + sp.bounds.size.y / 2);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
