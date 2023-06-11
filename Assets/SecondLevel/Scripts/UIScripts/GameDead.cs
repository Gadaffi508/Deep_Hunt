using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDead : UIController
{
    public void LoadRery(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }
}
