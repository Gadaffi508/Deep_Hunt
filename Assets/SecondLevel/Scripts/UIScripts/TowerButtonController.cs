using UnityEngine;

public class TowerButtonController : UIController
{
    [SerializeField] BuiltTower[] allButtons;

    private tower currentArea;
    public tower SetTower(tower tower) => currentArea = tower;
    public bool clicked = false;

    public GameObject ImageInfor;
    public bool tutImage = false;

    //Event Implements
    private void OnEnable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonClick += ButtonClick;
        }
    }
    private void OnDisable()
    {
        foreach (var button in allButtons)
        {
            button.OnButtonClick -= ButtonClick;
        }
    }
    private void ButtonClick(GameObject _Tower)
    {
        if (currentArea != null)
        {
            currentArea.TowerBuilt(_Tower);
            clicked = true;

            if (tutImage == true)
            {
                ImageInfor.SetActive(true);
                Destroy(ImageInfor, 7f);
                tutImage = false;
                TutorialSecond.tutorialInst.BuilTower = true;
            }
        }
    }
}
