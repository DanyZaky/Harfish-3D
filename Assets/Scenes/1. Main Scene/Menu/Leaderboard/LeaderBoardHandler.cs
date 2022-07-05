using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardhandler : MonoBehaviour
{
    private int currentPosition;
    private bool hias, konsumsi;
    [SerializeField] GameObject[] menu;
    void Start()
    {
        currentPosition = 0;
    }

    public void Next()
    {
        currentPosition++;
        if(hias)
            if(currentPosition >= 14) currentPosition = 0;
        if(konsumsi)
            if(currentPosition >= 6) currentPosition = 0;
    }

    public void Back()
    {
        currentPosition--;
        if(hias)
            if(currentPosition <= -1) currentPosition = 13;
        if(konsumsi)
            if(currentPosition <= -1) currentPosition = 5;
    }

    public void Return()
    {
        menu[0].SetActive(true);
        if(hias)
        {
            menu[1].SetActive(false);
            hias = false;
        }
        if(konsumsi)
        {
            menu[2].SetActive(false);
            konsumsi = false;
        }
    }


}
