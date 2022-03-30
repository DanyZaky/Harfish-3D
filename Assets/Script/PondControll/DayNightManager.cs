using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightManager : MonoBehaviour
{
    GameObject fishPond;
    PondScript pondCs;

    [SerializeField] private TextMeshProUGUI phLevelInfo;
    [SerializeField] private GameObject DayLight, NightLight;

    public string dayPhase;

    void Start()
    {
        // GameObject dayCycle = GameObject.Find("day cycle");
        // dayNightScript pondCs = dayCycle.GetComponent<dayNightScript>();
        fishPond = GameObject.Find("Enviroment");
        pondCs = fishPond.GetComponent<PondScript>();
        //Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dayPhase = pondCs.getDayPhase();
        if (dayPhase == "daylight")
        {
            phLevelInfo.SetText("PH = 8");
            DayLight.SetActive(true);
            NightLight.SetActive(false);

        }

        else if (dayPhase == "night")
        {
            phLevelInfo.SetText("PH = 5");
            DayLight.SetActive(true);
            NightLight.SetActive(false);
        }
    }
}
