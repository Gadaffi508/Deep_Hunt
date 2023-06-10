using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatChallangeAndRotate : MonoBehaviour
{
    private bool isFollowingMouse = false;
    float angle;
    public float rotationSpeed = 3;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.name == "Rotate")
            {
                isFollowingMouse = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isFollowingMouse = false;
        }

        if (isFollowingMouse)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            // Ok objesinin ucu, fare pozisyonuna doðru yönlendirilecek
            Vector2 direction = (mousePosition - transform.position).normalized;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        if (isFollowingMouse == false)
        {

            Quaternion targetRotation = Quaternion.identity; // Eski dönüþ deðeri
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    
}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Text1"))
        {
            StartCoroutine(MouseExit(other));
        }
        if (other.gameObject.CompareTag("Text2"))
        {
            StartCoroutine(MouseExit(other));
        }
    }
    IEnumerator MouseExit(Collision2D other)
    {
        gameObject.name = "RotateExit";
        isFollowingMouse = false;
        yield return new WaitForSeconds(1.5f);
        other.gameObject.GetComponent<BoatManager>().ChangeScene(2);
    }
}
