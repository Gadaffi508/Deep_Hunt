using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatGame : MonoBehaviour
{
    public BoatDataBase boatdbs;

    public GameObject artworkObject;

    public int direction;

    private void Start()
    {
        UpdateBoat(boatdbs);
        Instantiate(artworkObject, artworkObject.transform.position, Quaternion.identity);
    }

    private void UpdateBoat(BoatDataBase boatChoose)
    {
        direction = Load("direction");
        artworkObject = boatChoose.boat[direction].boat;
    }
    public int Load(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
