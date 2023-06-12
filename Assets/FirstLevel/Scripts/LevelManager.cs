using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelM = 1;
    public static LevelManager instanceLevel;

    private void Start()
    {
        if (instanceLevel != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instanceLevel = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void NextLevel()
    {
        levelM++;
    }
    public void LoadMapScene()
    {
        StartCoroutine(loadMapScene());
    }

    IEnumerator loadMapScene()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(CameraDelay.instance.StartScene());
    }

    public void LoadBoat()
    {
        if (levelM>1)
        {
            //GameManager.Instance.GameobjectBoat();
        }
    }
    public void DelayCam()
    {
        GameManager.Instance.CamActive();
    }
}
