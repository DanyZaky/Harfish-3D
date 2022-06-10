using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Suhu : MonoBehaviour
{
    private int suhuKolam,suhuSekarang;
    [SerializeField] private Toggle onOff;
    [SerializeField] private TextMeshProUGUI teksSuhuKolam, teksPengaturSuhu, teksStatusKolam;
    [SerializeField] private Slider pengaturSuhu;

    void Start()
    {
        suhuKolam = Random.Range(10, 30);
        suhuSekarang = suhuKolam;
        teksPengaturSuhu.text = pengaturSuhu.value.ToString()+ "°C";
    }

    // Update is called once per frame
    void Update()
    {
        if(suhuKolam >= 18 & suhuKolam <= 26)
        {
            teksStatusKolam.text = "Suhu kolam normal";
        }
        else 
        {
            teksStatusKolam.text = "Nyalakan dan atur suhu antara 18°C - 26°C";
        }
        if(onOff.isOn)
        {
           PengaturSuhu();
        }
        else 
        {
            suhuKolam = suhuSekarang;
        }
        teksPengaturSuhu.text = pengaturSuhu.value.ToString() + "°C";
        teksSuhuKolam.text = "Suhu " + suhuKolam.ToString() + "°C";
    }

    public void PengaturSuhu()
    {
        suhuKolam = (int)pengaturSuhu.value;
    }

}
