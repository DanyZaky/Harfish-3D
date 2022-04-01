using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    private bool isPowerUp;
    private float powerCount, powerCountCounter;
    [SerializeField] RectTransform powerParameter;
    void Start()
    {
        powerCount = 0f;
        powerCountCounter = powerCount;
    }

    void Update()
    {
        if (isPowerUp)
        {
            powerCountCounter += 1f;

            if(powerCountCounter >= 380f)
            {
                isPowerUp = false;
            }
        }

        if(!isPowerUp)
        {
            powerCountCounter -= 1f;
            if (powerCountCounter <= 0f)
            {
                isPowerUp = true;
            }
        }

        Debug.Log("power = "+ powerCountCounter);
    }
}
