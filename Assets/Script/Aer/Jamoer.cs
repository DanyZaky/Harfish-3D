using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jamoer : MonoBehaviour
{
    private ObatJamoer oj;
    void Start()
    {  
        oj = GameObject.Find("ObatJamuran").GetComponent<ObatJamoer>();
    }
    private void OnMouseDown()
    {
        if(oj.Obat() == true)
        {
            oj.Terbunuh(false);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.tag == "Ikan")
    //     {
    //         Destroy(gameObject);
    //     }
    // }

}
