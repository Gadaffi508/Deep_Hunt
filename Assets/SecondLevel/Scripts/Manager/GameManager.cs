using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    public Text Goldtext;
    public GameObject GoldImage;
    public Text HealthText;

    public GameObject boat;
    public GameObject Cam;

    public int Gold;
    public float Health;

    public Image Healtbar;
    public GameObject HealtbarBG;

    private AudioSource audio;

    public AudioClip[] DamageSounds;
    public static GameManager Instance;

    public int damagedecrease = 0;
    public bool built = true;
    public bool clicka = true;
    public bool clickb = true;
    public bool clickc = true;
    public bool clickd = true;

    LevelManager levelManager;

    public bool levelM = true;
    public bool ManM = true;

    public List<GameObject> enemyL = new List<GameObject>();

    public string ýnformatoýnTower;
    public GameDead deadScene;
    public GameDead NextScene;
    public Vector2 boatFirstPos;
    public bool finished = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();

        if (ManM == true)
        {
            if (Instance != null)
            {
                Instance.gameObject.SetActive(false);
                Destroy(this.gameObject);
                return;
            }
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        Instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        HealtbarBG.SetActive(true);
        Healtbar.gameObject.SetActive(true);
        Goldtext.gameObject.SetActive(true);
        GoldImage.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (Goldtext != null)
        {
            Goldtext.text = Gold.ToString();
        }

        if (finished == true && enemyL.Count <= 0)
        {
            NextScene.Show();
            boat.GetComponent<BoatController>().enabled = false;
            boatFirstPos = boat.transform.position;
        }

        if (GameObject.FindGameObjectWithTag("Ship") != null)
        {
            boat = GameObject.FindGameObjectWithTag("Ship").gameObject;
        }

        for (int i = 0; i < enemyL.Count; i++)
        {
            if (enemyL[i] == null)
            {
                enemyL.Clear();
            }
        }
    }


    public void Heal(float healingAmount)
    {
        Health += healingAmount;

        Healtbar.fillAmount = Health / 200;
    }


    public void TakeDamage(float damage)
    {
        int random = Random.Range(0, DamageSounds.Length);
        audio.PlayOneShot(DamageSounds[random]);
        Health -= Mathf.Abs((damage - damagedecrease)); // health = health - damage - (damagedecrease)
        Healtbar.fillAmount = Health / 200;

        if (Health <= 0)
        {
            deadScene.Show();
        }
    }

    public void nextScene(int sceneÝD)
    {
        SceneManager.LoadScene(sceneÝD);
    }
    public void GameobjectBoatActive()
    {
        HealtbarBG.SetActive(false);
        Healtbar.gameObject.SetActive(false);
        boat.SetActive(false);
        boat.GetComponent<BoatController>().enabled = true;
        Goldtext.gameObject.SetActive(false);
        GoldImage.SetActive(false);
        if (Health < 200)
        {
            Health += 50;
            if (Health >= 200)
            {
                Health = 200;
            }
        }

        //levelManager.LoadMapScene();
        //StartCoroutine(loadCamDelay());
    }
    public void GameobjectBoat()
    {
        HealtbarBG.SetActive(true);
        Healtbar.gameObject.SetActive(true);
        boat.SetActive(true);
        Goldtext.gameObject.SetActive(true);
        GoldImage.SetActive(true);
        boat.GetComponent<BoatController>().enabled = true;
        boat.transform.position = new Vector3(0, boatFirstPos.y + 0.2f);
    }
    public void CamActive()
    {
        Cam.SetActive(true);
    }

    public void ResetScene()
    {
        finished = false;
        NextScene.Hide();
    }

    public void AddEnemyToList(GameObject enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            enemyL.Add(enemy);
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if (enemyL.Contains(enemy))
        {
            enemyL.Remove(enemy);
        }
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        RemoveEnemyFromList(enemy);
        Destroy(enemy);
    }


}
