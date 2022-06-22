using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Netas : MonoBehaviour
{
    [SerializeField] private GameObject telor,ikan;
    [SerializeField] private Vector3 lokasi, area;
    [SerializeField] private float untukMenetas;
    [SerializeField] private int jumlah;
    public bool netas;
   

    void Start()
    {
        netas = false;
        //jumlah = (int)(PlayerPrefs.GetFloat("MixingCount"));
        for(int i = 0; i<jumlah; i++)
        {
            MunculinTelor();
        }
    }

    void Update()
    {
        if (untukMenetas > 0)
        {
            untukMenetas -= Time.deltaTime;
        }
        else if( untukMenetas < 0 && jumlah > 0)
        {
           netas = true;
            MunculinIkan();
            jumlah--;
        }
        if(jumlah == 0)
        {
            GameObject[] jmlTelor = GameObject.FindGameObjectsWithTag("Telur");
            for(int i = 0 ; i < jmlTelor.Length ; i++)
                Destroy(jmlTelor[i]);
            jumlah--;
        }
    }

    void MunculinIkan()
    {    
        Vector3 posisi = lokasi + new Vector3(Random.Range(-area.x / 2, area.x / 2), Random.Range(-area.y / 2, area.y / 2),Random.Range(-area.z / 2, area.z / 2));
        Instantiate(ikan, posisi, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawCube(lokasi, area);
    }

    void MunculinTelor()
    {
        Vector3 posisi = lokasi + new Vector3(Random.Range(-area.x / 2, area.x / 2), Random.Range(-area.y / 2, area.y / 2),Random.Range(-area.z / 2, area.z / 2));
        Instantiate(telor, posisi, Quaternion.identity);
    }
}

