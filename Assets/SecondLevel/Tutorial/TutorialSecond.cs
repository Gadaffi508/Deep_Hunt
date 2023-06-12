using System.Collections;
using UnityEngine;
using DG.Tweening;

public class TutorialSecond : MonoBehaviour
{
    public GameObject[] destg;
    public LayerMask OpenTowerObject;
    public GameObject ImageInformationwhite;
    public GameObject ImageInformationred;
    public GameObject ImageInformationgreen;
    public GameObject[] warning;
    BoatController boat;
    public GameObject cam;
    int fullarea = 0;
    public Transform point1, point2, flypoin1, flyPoint2;
    public GameObject normalEnemy, TankEnemy, flyEnemy;
    public GameObject SpawnEnemy;

    public static TutorialSecond tutorialInst;
    public bool BuilTower = false;

    public GameObject[] Bars;

    private void Start()
    {
        tutorialInst = this;
        ImageInformationwhite.SetActive(false);
        ImageInformationred.SetActive(false);
        ImageInformationgreen.SetActive(false);
    }

    private void OnDisable()
    {
        Destroy(boat.gameObject);
    }

    public void DestBar()
    {
        foreach (GameObject bar in Bars)
        {
            Destroy(bar);
        }
            

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

                if (hit.collider.name == "white")
                {
                    if (ImageInformationwhite != null)
                    {
                        ImageInformationwhite.SetActive(true);
                        Destroy(ImageInformationwhite, 3f);
                        if (warning[0] != null)
                        {
                            warning[0].SetActive(false);
                            fullarea += 1;
                        }
                    }
                }
                if (hit.collider.name == "red")
                {
                    if (ImageInformationred != null)
                    {
                        ImageInformationred.SetActive(true);
                        Destroy(ImageInformationred, 3f);
                        if (warning[1] != null)
                        {
                            warning[1].SetActive(false);
                            fullarea += 1;
                        }
                    }
                }
                if (hit.collider.name == "green")
                {
                    if (ImageInformationgreen != null)
                    {
                        ImageInformationgreen.SetActive(true);
                        Destroy(ImageInformationgreen, 3f);
                        if (warning[2] != null)
                        {
                            warning[2].SetActive(false);
                            fullarea += 1;
                        }
                    }
                }
            }
            if (BuilTower == true && fullarea >= 2)
            {
                SpawnPoint();
                BuilTower = false;
            }
        }
        if (fullarea > 2)
        {
            boat = GameObject.FindGameObjectWithTag("Ship").GetComponent<BoatController>();
            boat.GetComponent<BoatController>().enabled = true;
        }
    }

    public void DestroyGameobjecs()
    {
        for (int i = 0; i < destg.Length; i++)
        {
            Destroy(destg[i]);
        }
    }

    public void SpawnPoint()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        Instantiate(TankEnemy, point1.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Instantiate(normalEnemy, point1.position, Quaternion.identity);
        Instantiate(flyEnemy, flypoin1.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(normalEnemy, point1.position, Quaternion.identity);
        yield return new WaitForSeconds(6);
        Instantiate(TankEnemy, point2.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
        Instantiate(normalEnemy, point2.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(normalEnemy, point2.position, Quaternion.identity);
        Instantiate(flyEnemy, flyPoint2.position, Quaternion.identity);
        GameManager.Instance.finished = true;

    }
}