using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JumlahTelur : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI jumlahTelur;
    

    public float jmlTelur;

    private void Update()
    {
        jumlahTelur.SetText(jmlTelur.ToString("0"));
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Telur")
        {
            jmlTelur += 1;
            SoundManager.Instance.PlaySFX("SFX Dropping");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Telur")
        {
            jmlTelur -= 1;
        }
    }
}
