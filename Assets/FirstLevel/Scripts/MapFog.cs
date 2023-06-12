using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MapFog : MonoBehaviour
{
    [SerializeField] Camera cam;
    SpriteRenderer sp;

    Vector3 startingPosition;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        Close();
    }

    public void Show(float toY)
    {
        gameObject.SetActive(true);
        startingPosition = new Vector3(transform.position.x, Camera.main.orthographicSize + sp.bounds.size.y / 2);
        transform.position = startingPosition;

        transform.DOMoveY(toY, 1);
    }
    public void Hide()
    {
        startingPosition = new Vector3(transform.position.x, Camera.main.orthographicSize + sp.bounds.size.y / 2);
        transform.DOMoveY(startingPosition.y, 1);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
