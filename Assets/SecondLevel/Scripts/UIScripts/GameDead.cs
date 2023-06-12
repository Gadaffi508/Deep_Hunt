using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDead : UIController
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
        DOTween.To(() => myRect.anchoredPosition, x => myRect.anchoredPosition = x, new Vector2(myRect.anchoredPosition.x, -inActiveY), 1).OnComplete(()=> Time.timeScale = 0);
    }

    public void LoadRery(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }


}
