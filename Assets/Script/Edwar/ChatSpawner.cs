using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSpawner : MonoBehaviour
{
    public GameObject chatObj;

    bool isSpawning;
    public float timeChatSpawn, timeChatSpawnCounter;

    private void Start()
    {
        isSpawning = false;
        timeChatSpawnCounter = timeChatSpawn;
    }

    private void Update()
    {
        timeChatSpawnCounter -= 1f * Time.deltaTime;

        if(isSpawning == false)
        {
            if (timeChatSpawnCounter <= 0)
            {
                timeChatSpawnCounter = timeChatSpawn;
                isSpawning = true;
            }
        }   
        
        if(isSpawning == true)
        {
            chatObj.SetActive(true);
        }
    }

    public void buttonSell()
    {
        chatObj.SetActive(false);
        isSpawning = false;
        timeChatSpawnCounter = timeChatSpawn;
    }
}
