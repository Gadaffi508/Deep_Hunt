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
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
        load = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
        unLoad = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        Debug.Log(unLoad);
        while (load != null && unLoad != null)
        {
            if (load.isDone)
                load = null;

            if (unLoad.isDone)
                unLoad = null; 

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();

        Debug.Log("Loaded");
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneID));
        MapManager.instance.SetCanvasCamera();
    }

    public void Save(string KeyName, int _direction)
    {
        PlayerPrefs.SetInt(KeyName, _direction);
    }
}
