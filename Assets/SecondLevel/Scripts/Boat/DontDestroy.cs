using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public static DontDestroy dontDestroyed;


    private void Start()
    {
        if (dontDestroyed != null)
        {
            Destroy(this.gameObject);
            return;
        }
        dontDestroyed = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
