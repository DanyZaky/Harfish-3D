using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObatJamoer : MonoBehaviour
{
    [SerializeField] private GameObject obatJamoerGameobj;
    [SerializeField] private Button btnObat;
    
    private bool berobat;

    void Start()
    {
        obatJamoerGameobj.SetActive(false);
    }

    void Update()
    {
        Vector2 cursorPos = Input.mousePosition;
        obatJamoerGameobj.transform.position = new Vector2(cursorPos.x, cursorPos.y);
        
        if(obatJamoerGameobj.activeSelf == true)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                Terbunuh(false);
            }
        }
    }

    public void btnObatJamoer()
    {
        berobat = true;
        btnObat.interactable = false;   
        obatJamoerGameobj.SetActive(true);
    }

    public bool Obat()
    {
        return berobat;
    }

    public void Terbunuh(bool status)
    {
        berobat = status;
       

        btnObat.interactable = true;
        obatJamoerGameobj.SetActive(false);
    }
    
}
