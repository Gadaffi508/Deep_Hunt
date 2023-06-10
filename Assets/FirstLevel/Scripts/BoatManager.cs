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

    private void Awake()
    {
        spt = GetComponent<SpriteRenderer>();
        Save("direction", direction);
        der = PlayerPrefs.GetInt("direction", direction);
    }

    public void ChangeScene(int sceneID)
    {
        Save("direction", direction);
        SceneManager.LoadScene(sceneID);
    }
    public void Save(string KeyName, int _direction)
    {
        PlayerPrefs.SetInt(KeyName, _direction);
    }
}
