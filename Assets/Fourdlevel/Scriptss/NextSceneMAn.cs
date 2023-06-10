using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneMAn : MonoBehaviour
{
    public void NextScene(int scene›D)
    {
        SceneManager.LoadScene(scene›D);
    }
}
