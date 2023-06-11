using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMapButton : MonoBehaviour
{
    public void OpenMap()
    {
        MapManager.instance.OpenMap();
    }
}
