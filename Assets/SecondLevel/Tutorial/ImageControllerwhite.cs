using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageControllerwhite : MonoBehaviour
{
    tower _offset;

    private void FixedUpdate()
    {
        _offset = GameObject.FindObjectOfType<tower>();
        if (_offset.name == "white")
        {
            transform.position = new Vector2(_offset.transform.position.x - 0.3f, _offset.transform.position.y + 0.5f);
        }
    }
}
