using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class timer : MonoBehaviour
{
    public bool timerActive = false;
    public bool timeisup = false;
    public bool ikan = false;
    float currentTime;
    public int startSeconds;
    public TextMeshProUGUI currentTimeText;
    public GameObject kalah;

    private bool isWin;

    [SerializeField] private ProgressBars pb;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startSeconds * 1;
        isWin = true;

        
    }
    
    // Update is called once per frame
    public void Update()
    {
        /*if (ikan == true)
        {
            timerActive = true;
        }*/

        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <= 0)
            {
                timerActive = false;
                timeisup = true;
                kalah.SetActive(timeisup);
                ikan = false;
                Debug.Log("waktu habis");

                if (isWin)
                {
                    SoundManager.Instance.PlaySFX("SFX Win");
                    isWin = false;
                }

                pb.hasilPijahText.SetText(pb.currentJumlahTelur.ToString("0"));

                if (pb.currentJumlahTelur > PlayerPrefs.GetFloat("TerpijahCount"))
                {
                    PlayerPrefs.SetFloat("TerpijahCount", pb.currentJumlahTelur);
                }

                pb.highScoreText.SetText(PlayerPrefs.GetFloat("TerpijahCount").ToString("0"));
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        //currentTimeText = time.Minutes.ToString()+ ":" + time.Seconds.ToString();
         currentTimeText.SetText(currentTime.ToString("0"));
    }
    public void mulaiwaktu()
    {
        ikan = true;
    }
    public void StartTimer()
    {
        timerActive = true;
        // kalah.SetActive(timeisup);
    }
    public void StopTimer(){
        timerActive = false;
        timeisup = false;
    }
        
    
}
