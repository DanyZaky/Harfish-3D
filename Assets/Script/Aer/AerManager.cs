using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AerManager : MonoBehaviour
{
    private int jumlahBenih;
    [SerializeField] private TextMeshProUGUI waktuText,benihText,HasilText, pauseText;
    [SerializeField] float waktuGame;
    [SerializeField] private GameObject EndUI, pauseUI;
    [SerializeField] Netas nts;
    public bool isPaused;



    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        
        waktuText.text = waktuGame.ToString("#");
        if(nts.netas == false)
        {
            jumlahBenih = GameObject.FindGameObjectsWithTag("Telur").Length;
            benihText.text = "Jumlah telur ikan " + jumlahBenih.ToString( "#") + " Butir";
        }
        else 
        {
            jumlahBenih = GameObject.FindGameObjectsWithTag("Ikan").Length;
            benihText.text = "Jumlah Benih " + jumlahBenih.ToString( "#") + " Ekor";
        }
        
        
        if(waktuGame > 0)
        {
            waktuGame -= Time.deltaTime;
        }
        if (waktuGame < 0 || jumlahBenih < 0 )
        {
            waktuGame = 0;
            End();
        }
    }

    private void End()
    {
        HasilText.text = jumlahBenih.ToString("#");
        PlayerPrefs.SetFloat("JumlahBenih", jumlahBenih);
        Time. timeScale = 0;
        EndUI.SetActive(true);
        isPaused = true;
    }

    public void Pause()
    {
        Time. timeScale = 0;
        pauseText.text = jumlahBenih.ToString("#");
        pauseUI.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Time. timeScale = 1;
        pauseUI.SetActive(false);
        isPaused = false;
    }

}
