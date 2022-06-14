using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PesanMasuk : MonoBehaviour
{
    [SerializeField] private GameObject Message;
    private float time = 59f;
    private float timeCounter;
    private void Start()
    {
        timeCounter = time;
        transform.GetComponent<Button>().onClick.AddListener(() => openMessage());

    }
    private void Update()
    {
        timeCounter -= 1f * Time.deltaTime;


        GameObject aa = transform.GetChild(1).GetChild(1).gameObject;
        aa.transform.GetComponent<TMPro.TextMeshProUGUI>().text = Mathf.Round(timeCounter).ToString();
        if (timeCounter <= 1)
        {
            //buttonCloseNotif();
        }
    }
    public void openMessage()
    {
        Message.gameObject.SetActive(true);
    }

}