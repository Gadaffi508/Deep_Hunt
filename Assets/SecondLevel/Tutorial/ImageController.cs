using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    TowerBottom _offset;

    private void FixedUpdate()
    {
        _offset = GameObject.FindObjectOfType<TowerBottom>();
        if (_offset.name == "red")
        {
            transform.position = new Vector2(_offset.transform.position.x - 0.3f, _offset.transform.position.y + 0.5f);
        }
    }

}
