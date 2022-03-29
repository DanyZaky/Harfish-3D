using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timePerCycle = 12f;
    public float dayCycle = 12f;
    public float nightCycle = 12f;
    public int dayCounter = 0;
    public float phLevel = 0;
    public float temperatureLevel = 0f;
    public float oksigenLevel = 5f;
    public float cleanessLevel = 0f;
    bool isDay = true;
    public bool isStart = false;
    public int dayPhase = 0;

    public int maxPondCapacity = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dayCounterFunc();
    }

    public void dayCounterFunc()
    {
        if (isStart)
        {

            if (dayPhase == 2)
            {
                dayCounter += 1;
                // Debug.Log(dayCounter);
                // Debug.Log(getDayPhase());
                dayPhase = 0;
            }

            if (isDay && dayCycle > 0)
            {
                dayCycle -= Time.deltaTime;
            }
            else if (dayCycle < 0)
            {
                isDay = false;
                dayCycle = timePerCycle;
                dayPhase += 1;
            }

            if (!isDay && nightCycle > 0)
            {
                nightCycle -= Time.deltaTime;
            }
            else if (nightCycle < 0)
            {
                isDay = true;
                nightCycle = timePerCycle;
                dayPhase += 1;
            }
        }
    }
    public void dayOrNightCycle()
    {
        if (isDay)
        {
            isDay = false;
        }
        else if (!isDay)
        {
            isDay = true;
        }
    }

    public string getDayPhase()
    {
        if (isDay)
        {
            return "daylight";
        }
        else
        {
            return "night";
        }
    }

    public float GetPhLevel()
    {
        return phLevel;
    }

    public float GetTemperatureLevel()
    {
        return temperatureLevel;
    }

    public float GetOksigenLevel()
    {
        return oksigenLevel;
    }

    public float GetCleanessLevel()
    {
        return cleanessLevel;
    }
}
