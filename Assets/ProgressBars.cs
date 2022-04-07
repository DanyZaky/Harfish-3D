using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBars : MonoBehaviour
{
    public Image progressbarfill;
    public float maksJumlahTelur, jumlahTelur;
    private float currentJumlahTelur;
    public GameObject menang;
    public bool aktif = false;
    
    private void Start()
    {
        progressbarfill.fillAmount = 0;
        currentJumlahTelur = jumlahTelur;
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Telur")
        {
            currentJumlahTelur = currentJumlahTelur + 1;
            progressbarfill.fillAmount = currentJumlahTelur / maksJumlahTelur;
            Debug.Log("tersentuh"+currentJumlahTelur);
        }
    }
   private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Telur")
        {
            currentJumlahTelur = currentJumlahTelur - 1;
            progressbarfill.fillAmount = currentJumlahTelur / maksJumlahTelur;
            Debug.Log("telur terangkat");
        }
    }
    public void Update()
    {
        if(currentJumlahTelur >= maksJumlahTelur)
        {
            Debug.Log("menang");
            menang.SetActive(aktif);
            timer.FindObjectOfType<timer>().ikan = false;
            timer.FindObjectOfType<timer>().timerActive = false;
            
        }
    }
}

  
    
    

