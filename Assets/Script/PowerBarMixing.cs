using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBarMixing : MonoBehaviour
{
    private bool isPowerUp;
    public bool isPowerRunning;

    [HideInInspector] public float powerCount, powerCountCounter;
    [SerializeField] RectTransform powerParameter;
    [SerializeField] float speedParameter;

    void Start()
    {
        powerCount = 0f;
        powerCountCounter = powerCount;

        isPowerRunning = true;
    }

    void Update()
    {
        if (isPowerRunning)
        {
            if (isPowerUp)
            {
                powerCountCounter += 1f * speedParameter;
                powerParameter.anchoredPosition = new Vector2(0, powerCountCounter);

                if (powerCountCounter >= 430f)
                {
                    isPowerUp = false;
                }
            }

            if (!isPowerUp)
            {
                powerCountCounter -= 1f * speedParameter;
                powerParameter.anchoredPosition = new Vector2(0, powerCountCounter);

                if (powerCountCounter <= -430f)
                {
                    isPowerUp = true;
                }
            }
        }
    }
}
