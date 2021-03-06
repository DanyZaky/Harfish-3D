using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JumlahTelur : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI jumlahTelur;

    [SerializeField] private SpeedMixing sm;
    public float jmlTelur;

    private void Update()
    {
        jumlahTelur.SetText(jmlTelur.ToString("0"));
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Telur")
        {
            jmlTelur += (Random.Range(0f, 5f) + 20f);
            SoundManager.Instance.PlaySFX("SFX Dropping");
        }

        if(col.gameObject.tag == "sperm")
        {
            sm.isAdaSelSperma = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Telur")
        {
            jmlTelur -= 19f;
        }
    }
}
