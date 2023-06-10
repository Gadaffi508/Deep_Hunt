using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoatDataBase : ScriptableObject
{
    public BoatChoose[] boat;

    public int boatCount
    {
        get
        {
            return boat.Length;
        }
    }
}
