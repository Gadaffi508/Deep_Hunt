using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] soundbg;

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSound()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        for (int i = 0; i < soundbg.Length; i++)
        {
            soundbg[i].SetActive(true);
        }
    }

    public void CloseSound()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        for (int i = 0; i < soundbg.Length; i++)
        {
            soundbg[i].SetActive(false);
        }
    }
}
