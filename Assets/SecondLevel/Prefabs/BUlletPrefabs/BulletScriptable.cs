using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class BulletScriptable : ScriptableObject
{
    public GameObject bullet;
    public SpriteRenderer spt;
    public ArrowScripts bulletCurrent;

    public GameObject InstateBullet(Transform bulletPos,Transform Rotate)
    {
        return Instantiate(bullet, bulletPos.position, Rotate.rotation);
    }
}
