using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamagedFish : MonoBehaviour
{
    [SerializeField] private StripTrigger st;

    [SerializeField] private GameObject tergigitText;
    [SerializeField] private TextMeshProUGUI jumalhTelurText;
    [SerializeField] private Image progressBar;
    void Update()
    {
        if(st.isDamagedFish == true)
        {
            tergigitText.SetActive(true);
            st.jumlahTelur -= 0.1f;
            jumalhTelurText.SetText(st.jumlahTelur.ToString("0"));
            progressBar.fillAmount = st.jumlahTelur / st.maxJumlahTelur;
        }

        if (st.isDamagedFish == false)
        {
            tergigitText.SetActive(false);
        }
    }
}
