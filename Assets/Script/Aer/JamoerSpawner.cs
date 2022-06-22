using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamoerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[]   ikans;
    [SerializeField] private GameObject jamoer;
    [SerializeField] private Vector3 lokasi, area;
    [SerializeField] private float tiapDetik;
   // [SerializeField] private int jumlahMaksimal;
    private float waktu;
    [SerializeField] private Penyakit penyakit;
    void Start()
    {
        waktu = tiapDetik;
        //jumlahMaksimal = ;
    }

    void Update()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Jamur").Length + "/" +jumlahMaksimal);
        ikans = GameObject.FindGameObjectsWithTag("Ikan");
        
        if(GameObject.FindGameObjectsWithTag("Jamur").Length < ikans.Length)
        {
            if (waktu > 0)
            {
                waktu -= Time.deltaTime;
                
            }
            else
            {
                if(ikans.Length > 0)
                MunculinJamoer();
                
                waktu = tiapDetik;
            }
        }
    }

    void MunculinJamoer()
    {
            int ikan = Random.Range(0, ikans.Length);
            ikans[ikan].transform.GetChild(2).gameObject.SetActive(true);
            ikans[ikan].GetComponent<Ikan>().jamuran = true;
             GameObject terjamur = ikans[ikan].transform.GetChild(1).gameObject;
             terjamur.GetComponent<Renderer>().material.SetColor("_BaseColor", Color.green);
       // Vector3 posisi = lokasi + new Vector3(Random.Range(-area.x / 2, area.x / 2), Random.Range(-area.y / 2, area.y / 2),Random.Range(-area.z / 2, area.z / 2));

        //Instantiate(jamoer, posisi, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(lokasi, area);
    }

    

}
