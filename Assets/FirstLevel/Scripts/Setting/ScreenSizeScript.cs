using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeScript : MonoBehaviour
{
    [SerializeField] private Dropdown resolutionDrop;
    private Resolution[] resolutions;
    private List<Resolution> resolutionList;

    private float currentRefresh;
    private int currentResolutionIndex;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionList = new List<Resolution>();
        resolutionDrop.ClearOptions();
        currentRefresh = Screen.currentResolution.refreshRate;

        Debug.Log("ResulotionRate : " + currentRefresh);

        for (int i = 0; i < resolutions.Length; i++)
        {
            Debug.Log("Resulation : " + resolutions[i]);
            if (resolutions[i].refreshRate == currentRefresh)
            {
                resolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < resolutionList.Count; i++)
        {
            string resultionsOption = resolutionList[i].width + "x" + resolutionList[i].height + " " + resolutionList[i].refreshRate + " Hz";
            options.Add(resultionsOption);
            if (resolutionList[i].width == Screen.width && resolutionList[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDrop.AddOptions(options);
        resolutionDrop.value = currentResolutionIndex;
        resolutionDrop.RefreshShownValue();
    }

    public void SetResolution(int resolutionsindex)
    {
        Resolution resolution = resolutionList[resolutionsindex];
        Screen.SetResolution(resolution.width,resolution.height, true);
    }
}
