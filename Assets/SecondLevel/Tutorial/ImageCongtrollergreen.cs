using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCongtrollergreen : MonoBehaviour
{
    TowerUp _offset;

    private void FixedUpdate()
    {
        _offset = GameObject.FindObjectOfType<TowerUp>();
        if (_offset.name == "green")
        {
            transform.position = new Vector2(_offset.transform.position.x - 0.3f, _offset.transform.position.y + 0.5f);
        }
    }
}
