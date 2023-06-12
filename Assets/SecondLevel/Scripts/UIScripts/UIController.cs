using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private RectTransform myRect;

    public float inActiveY;

    void Start()
    {

        myRect = GetComponent<RectTransform>();

        inActiveY = myRect.anchoredPosition.y;
    }

    public void Show()
    {
        DOTween.To(() => myRect.anchoredPosition, x => myRect.anchoredPosition = x, new Vector2(myRect.anchoredPosition.x, -inActiveY), 1);
    }
    public void Hide()
    {
        DOTween.To(() => myRect.anchoredPosition, x => myRect.anchoredPosition = x, new Vector2(myRect.anchoredPosition.x, inActiveY), 1);
    }
}
