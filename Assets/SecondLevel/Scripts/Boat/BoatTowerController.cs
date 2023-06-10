using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BoatTowerController : MonoBehaviour
{
    public LayerMask OpenTowerObject;

    public abstract void TowerBuilt();
    public abstract void CloseTower();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = Vector2.zero;

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, direction, float.MaxValue, OpenTowerObject);

            if (hit.collider != null)
            {
                CloseTower();
                if (hit.collider.GetComponent<BoatTowerController>() != null)
                {
                    hit.collider.GetComponent<BoatTowerController>().TowerBuilt();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            CloseTower();
        }
    }
}

