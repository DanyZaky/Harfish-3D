using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AerManager : MonoBehaviour
{
    private int jumlahBenih;
    [SerializeField] private TextMeshProUGUI waktuText,benihText,HasilText;
    [SerializeField] float waktuGame;
    [SerializeField] private GameObject EndUI;

    void Update()
    {
        jumlahBenih = GameObject.FindGameObjectsWithTag("Ikan").Length;
        waktuText.text = waktuGame.ToString("#");
        benihText.text = jumlahBenih.ToString( "#");
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
    }


}
