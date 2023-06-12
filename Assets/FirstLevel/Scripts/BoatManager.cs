using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoatManager : MonoBehaviour
{
    public Text nameText;
    public int direction;
    public int sceneID;
    public SpriteRenderer spt;
    int der;

    AsyncOperation load;
    AsyncOperation unLoad;
    private void Awake()
    {
        spt = GetComponent<SpriteRenderer>();
        Save("direction", direction);
        der = PlayerPrefs.GetInt("direction", direction);
    }

    public void ChangeScene(int sceneID)
    {
        Save("direction", direction);

        StartCoroutine(Loading());
    }
    public IEnumerator Loading()
    {
        //Load Map
        load = SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        while (load != null)
        {
            if (load.isDone)
                load = null;

            yield return new WaitForEndOfFrame();
        }
        yield return null;
        //Load level scene
        load = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
        while(load != null)
        {
            if (load.isDone)
                load = null;

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneID));

        //Unload Select scene
        unLoad = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(1));
        while (unLoad != null)
        {
            if (unLoad.isDone)
                unLoad = null; 

            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    public void Save(string KeyName, int _direction)
    {
        PlayerPrefs.SetInt(KeyName, _direction);
    }
}
