using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Suntik : MonoBehaviour
{
    [SerializeField] private float duration, currentDuration;
    private bool isDurating;
    private GetChildText gct;
    void Start()
    {
        currentDuration = duration;
        isDurating = false;
        //gct.textDuration.SetActive(false);
    }

    void Update()
    {
        if(isDurating == true)
        {
            currentDuration -= 1f * Time.deltaTime;

            if (currentDuration <= 0f)
            {
                isDurating = false;
                currentDuration = duration;

                Debug.Log("Siap ");
            }
        }

        Debug.Log(currentDuration.ToString("0"));
    }
    private void OnMouseDown()
    {
        Debug.Log("tyersuntik");
        isDurating = true;
    }
}
