using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadarPulse : MonoBehaviour
{
    public Transform player;
    public RectTransform mapRect;
    public float mapScale = 2f;

    void LateUpdate()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.z);
        Vector2 mapPos = new Vector2(playerPos.x / mapScale, playerPos.y / mapScale);
        mapRect.anchoredPosition = mapPos;
    }
}
