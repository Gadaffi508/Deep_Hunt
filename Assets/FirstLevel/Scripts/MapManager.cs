using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private LayerMask mapLayer;
    [SerializeField] private Canvas canvas;

    [SerializeField] private GameObject mapPanel;
    [SerializeField] private GameObject[] mapLevels;

    [SerializeField] private MapFog fog;
    [SerializeField] private float delay;

    private int index = 0;

    AsyncOperation load;
    AsyncOperation unLoad;

    private int currentSceneIndex;


    private void Start()
    {
        foreach (GameObject level in mapLevels)
        {
            level.SetActive(false);
        }
        mapLevels[index].SetActive(true);
        mapPanel.SetActive(false);
    }

    private void Update()
    {
        if (mapPanel.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, float.MaxValue, mapLayer);

            if(hit.collider != null)
            {
                MapLoader loader = hit.collider.GetComponent<MapLoader>();
                LoadScene(loader.SceneIndex);
            }
        }
    }

    public void ClosePanel()
    {
        mapPanel.SetActive(false);
    }

    public void OpenMap()
    {
        index++;

        mapPanel.SetActive(true);

        GameObject currentLevel = mapLevels[index];
        currentLevel.SetActive(true);

        Camera.main.GetComponent<CameraTutorial>().Target = mapLevels[index].transform;
    }

    public void LoadScene(int sceneIndex)
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        StartCoroutine(ChangeScene(sceneIndex));
    }
    private IEnumerator ChangeScene(int sceneIndex)
    {
        //Camera zoom
        while(Camera.main.orthographicSize > 3)
        {
            Camera.main.orthographicSize -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        fog.Show();
        fog.gameObject.transform.DOMoveY(mapLevels[index].transform.position.y, 1);

        yield return new WaitForSeconds(delay);


        unLoad = SceneManager.UnloadSceneAsync(currentSceneIndex);
        load = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);

        while (load != null)
        {
            if (load.isDone)
            {
                load = null;
            }
            yield return new WaitForEndOfFrame();
        }
        while (unLoad != null)
        {
            if (unLoad.isDone)
            {
                unLoad = null;
            }
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();

        SetCanvasCamera();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
    }

    public void SetCanvasCamera()
    {
        canvas.worldCamera = Camera.main;
    }
}
