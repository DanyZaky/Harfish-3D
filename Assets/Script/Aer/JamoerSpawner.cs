using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamoerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jamoer;
    [SerializeField] private Vector3 lokasi, area;
    [SerializeField] private float tiapDetik;
    [SerializeField] private int jumlahMaksimal;
    private float waktu;
    [SerializeField] private Penyakit penyakit;
    void Start()
    {
        waktu = tiapDetik;
    }

    void Update()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Jamur").Length + "/" +jumlahMaksimal);
        
        if(GameObject.FindGameObjectsWithTag("Jamur").Length < jumlahMaksimal)
        {
            if (waktu > 0)
            {
                waktu -= Time.deltaTime;
                
            }
            else
            {
                MunculinJamoer();
                
                waktu = tiapDetik;
            }
        }
    }

    void MunculinJamoer()
    {
        
        
        Vector3 posisi = lokasi + new Vector3(Random.Range(-area.x / 2, area.x / 2), Random.Range(-area.y / 2, area.y / 2),Random.Range(-area.z / 2, area.z / 2));

        Instantiate(jamoer, posisi, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(lokasi, area);
    }

    

}
