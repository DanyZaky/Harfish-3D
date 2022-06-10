using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oksidasi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI teksOksidasi,teksMesin,teksStatus;
    [SerializeField] private float minOksidasi, maksOksidasi, tiapWaktu;
    private float oksidasi, waktu, pengaruh;
    [SerializeField] private Slider kekuatanMesin;
    [SerializeField]
    private Toggle mesinGelembung;
    [SerializeField] private Penyakit penyakit;
    [SerializeField] private AerManager M;
    [SerializeField] Image bgKipas;

    // Start is called before the first frame update
    void Start()
    {
        oksidasi = minOksidasi + (maksOksidasi - minOksidasi)/2;
        waktu = tiapWaktu;
        pengaruh = Random.Range(-0.01f, 0);
        teksMesin.text = kekuatanMesin.value.ToString("#.0000");
    }

    // Update is called once per frame
    void Update()
    {
        if(!M.isPaused)
        {

            if (waktu>0)
            {
                waktu -= Time.deltaTime;
            }
            else if(waktu<=0)
            {
                pengaruh = Random.Range(-0.01f, 0);
                waktu = tiapWaktu;
            }
                oksidasi += pengaruh;
            teksOksidasi.text = "Oksigen " + oksidasi.ToString("#.00 dGH");
            if(oksidasi >  5 && oksidasi < 25)
            {
                teksStatus.text = "(Aman)";
                penyakit.KehabisanNapas(0);
            }
            else if(oksidasi < 5)
            {
                teksStatus.text = "(Bahaya) Nyalakan kipas";
                penyakit.KehabisanNapas(1.00f);
            }
            else if(oksidasi > 25)
            {
                teksStatus.text = "(Bahaya) Matikan kipas";
                penyakit.KehabisanNapas(1.00f);
            }

            if(mesinGelembung.isOn)
            {
                MesinGelembung();
            }
            else bgKipas.color = Color.red;
            teksMesin.text = kekuatanMesin.value.ToString("#.0000");
        }
    }

    public void MesinGelembung()
    {
            oksidasi += kekuatanMesin.value;
            bgKipas.color = Color.green;
            
        
    }


}
