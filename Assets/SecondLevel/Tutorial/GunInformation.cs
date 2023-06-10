using UnityEngine;

public class GunInformation : MonoBehaviour
{
    public GameObject gunýnforma;

    TowerButtonController buton;

    private void Start()
    {
        buton = GetComponent<TowerButtonController>();
        gunýnforma.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (buton.clicked == true)
        {
            buton.clicked = false;
            if (gunýnforma != null)
            {
                gunýnforma.SetActive(true);
                Destroy(gunýnforma, 3f);
            }
        }
    }

}