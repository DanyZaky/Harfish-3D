using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesanMasuk : MonoBehaviour
{
    private float time = 59f;
    private float timeCounter;
    private void Start()
    {
        timeCounter = time;
        GameObject btnClose = transform.GetChild(2).gameObject;
        btnClose.transform.GetComponent<Button>().onClick.AddListener(() => buttonCloseNotif());
    }
    private void Update()
    {
        timeCounter -= 1f * Time.deltaTime;


        GameObject aa = transform.GetChild(1).gameObject;
        aa.transform.GetComponent<TMPro.TextMeshProUGUI>().text = Mathf.Round(timeCounter).ToString();
        if (timeCounter <= 1)
        {
            buttonCloseNotif();
        }
    }
    public void buttonCloseNotif()
    {
        transform.gameObject.SetActive(false);
    }

}