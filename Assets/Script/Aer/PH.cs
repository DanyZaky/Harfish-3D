using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PH : MonoBehaviour
{
    private float phKolam;
    [SerializeField] private TextMeshProUGUI teksPH;

    void Start()
    {
        phKolam = Random.Range(6.8f, 7.8f);
        teksPH.text = "ph Air " + phKolam.ToString("#.0");
    }
}
