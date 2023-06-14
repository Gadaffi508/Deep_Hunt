using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    
    int number = 0;
    public GameObject pause;
    private void Start()
    {
        pause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && number == 0)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            number++;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && number == 1)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            number = 0;
        }
    }
}
