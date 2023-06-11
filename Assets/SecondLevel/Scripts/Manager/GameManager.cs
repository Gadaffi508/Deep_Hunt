using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Goldtext;
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
        if (GameObject.FindGameObjectWithTag("Ship") != null)
        {
            boat = GameObject.FindGameObjectWithTag("Ship").gameObject;
        }
    }

    private void FixedUpdate()
    {
        Goldtext.text = Gold.ToString();
        if (levelM)
        {
            levelManager = GameObject.FindGameObjectWithTag("Level").gameObject.GetComponent<LevelManager>();   
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
    }

    public void nextScene(int scene›D)
    {
        SceneManager.LoadScene(scene›D);
    }
    public void GameobjectBoatActive()
    {
        HealtbarBG.SetActive(false);
        Healtbar.gameObject.SetActive(false);
        boat.SetActive(false);
        levelManager.levelM += 1;
        if (Health < 200)
        {
            Health += 50;
            if (Health >= 200)
            {
                Health = 200;
            }
        }
        levelManager.LoadMapScene();
        StartCoroutine(loadCamDelay());
    }
    public void GameobjectBoat()
    {
        HealtbarBG.SetActive(true);
        Healtbar.gameObject.SetActive(true);
        boat.SetActive(true);
    }
    public void CamActive()
    {
        Cam.SetActive(true);
    }
    IEnumerator loadCamDelay()
    {
        yield return new WaitForSeconds(0.4f);
        Cam.SetActive(false);
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
