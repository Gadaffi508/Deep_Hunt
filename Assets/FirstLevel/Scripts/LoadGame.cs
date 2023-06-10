using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public LayerMask OpenTowerObject;
    public Camera Camera;
    Collider2D collider;
    public int levelL;
    public string Yazý;
    bool zoom = false;
    public int sceneID;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        if (CameraDelay.instance.level != levelL)
        {
            collider.enabled = false;
        }
        Camera = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, OpenTowerObject);

            if (hit.collider != null)
            {
                hit.collider.GetComponent<LoadGame>().CameraZoom();
            }
        }

        if (zoom)
        {
            Camera.orthographicSize -= Time.deltaTime;
            if (Camera.orthographicSize <= 3)
            {
                Camera.orthographicSize = 3;
                StartCoroutine(loadGame());
            }
        }
    }
    public void CameraZoom()
    {
        zoom = true;
    }
    IEnumerator loadGame()
    {
        Camera.GetComponent<CameraDelay>().FogOut();
        yield return new WaitForSeconds(1);
        LevelManager.instanceLevel.LoadBoat();
        SceneManager.LoadScene(sceneID);
        yield return new WaitForSeconds(1);
        LevelManager.instanceLevel.DelayCam();
    }
}
