using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountInBowl : MonoBehaviour
{
    private float jmlInBowl;
    [SerializeField] private string targetTag;
    [HideInInspector] public bool isAbis;
    private float delayCount, delayCountCounter;

    void Start()
    {
        jmlInBowl = 0f;
        isAbis = false;

        delayCount = 3f;
        delayCountCounter = delayCount;
    }

    void Update()
    {
        delayCountCounter -= 1f * Time.deltaTime;

        if(delayCountCounter <= 0)
        {
            if (jmlInBowl <= 0)
            {
                isAbis = true;
            }
        }
        
        

        Debug.Log(jmlInBowl);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == targetTag)
        {
            jmlInBowl += 1f;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == targetTag)
        {
            jmlInBowl -= 1f;
        }
    }
}
