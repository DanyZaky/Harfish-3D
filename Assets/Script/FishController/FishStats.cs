using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishStats : MonoBehaviour
{
    //water temperature based on a reaserch, please treat it carefully
    public string fishName = "bawal";
    public int fishAgeInDays = 0;
    public int stressLevel = 0;
    public int maxWaterTemperature = 37;
    public int minWaterTemperature = 9;
    public bool alive = true;
    public int sicknessLevel = 0;
    public int starveLevel = 0;
    public int maxStarveLevel = 10;
    public bool breedAble = false;
    public bool isMale = true;
    public float lifeSpan = 150;
    public float harvestDayCounter = 80f;
    public float timePerDay = 6f;
    public float timePerDayFixed = 6f;

    // 1 hour = 1s, 1 day = 24s, 1month = 720s
    public bool isReadyToHarvest = false;
    public float weight = 50f;
    public bool isTimeRunning = false;
    public int healthPoint = 100;

    public float fishMaxSize = 25f;
    public float fishMinSize = 1f;

    public float growthPerdayVar;
    PondScript pondCs;
    // Start is called before the first frame update
    void Start()
    {
        growthPerdayVar = growthPerday();
        pondCs = GameObject.Find("Enviroment").GetComponent<PondScript>();
        transform.localScale = new Vector3(fishMinSize / 2f, fishMinSize / 2f, fishMinSize / 2f);
        // pondScript pondCs = fishPond.GetComponent<pondScript>();
        // Debug.Log(ponsCs.GetOksigenLevel());
    }

    // Update is called once per frame
    void Update()
    {
        AgeCounter();
        harvestChecker();
        stressCalculator();
        diedCondition();
        // Debug.Log(fishAgeInDays);
        // GrowthBehaviour();
    }

    void GrowthBehaviour()
    {
        Vector3 growth = new Vector3(growthPerdayVar, growthPerdayVar, growthPerdayVar);
        transform.localScale += growth;
        // if (fishAgeInDays == 2)
        // {
        //     transform.localScale = new Vector3(1f, 1f, 1f);
        // }
    }

    float growthPerday()
    {
        return (fishMaxSize * 0.5f) / harvestDayCounter;
    }
    void AgeCounter()
    {
        if (isTimeRunning)
        {
            if (timePerDay > 0)
            {
                timePerDay -= Time.deltaTime;
            }
            else
            {
                fishAgeInDays += 1;
                harvestDayCounter -= 1;
                GrowthBehaviour();
                timePerDay = timePerDayFixed;
                starvingFunc();
            }
        }
    }

    void harvestChecker()
    {
        if (harvestDayCounter <= 0)
        {
            isReadyToHarvest = true;
        }
        else
        {
            isReadyToHarvest = false;
        }
    }
    void IsFishHasDeployed()
    { }

    void stressCalculator()
    {
        float cleanLv = pondCs.GetCleanessLevel();
        float phLv = pondCs.GetPhLevel();
        float tempLv = pondCs.GetTemperatureLevel();
        float o2Lv = pondCs.GetOksigenLevel();

        float totalStress = (cleanLv + phLv + tempLv + o2Lv) / 4;
        stressLevel = (int)Math.Round(totalStress);
    }

    void starvingFunc()
    {
        starveLevel += 1;
    }

    public void FeededFunc(int eat)
    {
        starveLevel -= eat;
    }

    void diedCondition()
    {
        if (starveLevel == maxStarveLevel)
        {
            Destroy(gameObject);
        }
    }
}
