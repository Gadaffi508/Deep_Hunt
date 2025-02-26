using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject boatmanager;
    public GameObject captanImagefirst;
    public GameObject captanImagesecond;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject button;
    public GameObject warningred;
    public GameObject warninggreen;
    public GameObject warningwhite;

    BoatController boat;
    private void Start()
    {
        boatmanager.SetActive(false);
        captanImagesecond.SetActive(false);
        Text2.SetActive(false);
    }

    public void BoatManagerActive()
    {
        boatmanager.SetActive(true);
        captanImagesecond.SetActive(true);
        Text2.SetActive(true);
        button.SetActive(true);
        warninggreen.SetActive(true);
        warningred.SetActive(true);
        warningwhite.SetActive(true);
        StartCoroutine(boatmanagerFalse());
    }
    IEnumerator boatmanagerFalse()
    {
        yield return new WaitForSeconds(.2f);

        boat = GameObject.FindGameObjectWithTag("Ship").GetComponent<BoatController>();
        boat.GetComponent<BoatController>().enabled = false;

        captanImagefirst.SetActive(false);
        Text1.SetActive(false);
        gameObject.SetActive(false);
    }
    
}
