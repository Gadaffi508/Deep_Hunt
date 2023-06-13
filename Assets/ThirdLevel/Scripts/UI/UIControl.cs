using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public GameObject ýmagefill;
    public GameObject ýmagebg;
    public LayerMask OpenTowerObject;

    private void Awake()
    {
        GameManager.Instance.built = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, OpenTowerObject);

            if (hit.collider != null)
            {
                GameManager.Instance.built = false;
            }
        }

        if (GameManager.Instance.built == true)
        {
            ýmagefill.SetActive(true);
            ýmagebg.SetActive(true);
        }
        else
        {
            ýmagefill.SetActive(false);
            ýmagebg.SetActive(false);
        }
    }

    public void FinishSceneLoad()
    {
        SceneManager.LoadScene(7);
    }
}
