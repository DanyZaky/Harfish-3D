using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[ExecuteInEditMode()]
public class ProgressBars : MonoBehaviour
{
    public Image progressbarfill;
    private float maksJumlahTelur, jumlahTelur;
    public float currentJumlahTelur;
    public GameObject menang;
    public bool aktif = false;

    private bool isWin;

    [SerializeField] public TextMeshProUGUI terpijahText, hasilPijahText;

    [SerializeField] private GameObject teluraMixedPrefabs;
    Vector3 pos = new Vector3(59.2f, 46f, -174f);

    private void Start()
    {
        progressbarfill.fillAmount = 0;
        currentJumlahTelur = jumlahTelur;

        maksJumlahTelur = PlayerPrefs.GetFloat("MixingCount");

        isWin = true;

        for (int i = 0; i < ((int)(PlayerPrefs.GetFloat("MixingCount") / 20)); i++)
        {
            Instantiate(teluraMixedPrefabs, pos, Quaternion.identity);
            pos.y += 10f;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Telur")
        {
            SoundManager.Instance.PlaySFX("SFX Dropping");
            currentJumlahTelur += (Random.Range(0f, 1f) + 20f);
            progressbarfill.fillAmount = currentJumlahTelur / maksJumlahTelur;
            Debug.Log("tersentuh"+currentJumlahTelur);

            terpijahText.SetText(currentJumlahTelur.ToString("0"));
        }
    }
   private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Telur")
        {
            currentJumlahTelur = currentJumlahTelur - 20f;
            progressbarfill.fillAmount = currentJumlahTelur / maksJumlahTelur;
            Debug.Log("telur terangkat");

            terpijahText.SetText(currentJumlahTelur.ToString("0"));
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
            
            hasilPijahText.SetText(currentJumlahTelur.ToString("0"));

            if(currentJumlahTelur > PlayerPrefs.GetFloat("TerpijahCount"))
            {
                PlayerPrefs.SetFloat("TerpijahCount", currentJumlahTelur);
            }
            

            //Destroy(GameObject.Find("Telur Mixed(Clone)"));

            if (isWin)
            {
                SoundManager.Instance.PlaySFX("SFX Win");
                isWin = false;
                
            }

        }
    }
}

  
    
    

