using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notif : MonoBehaviour
{
    private float time = 5f;
    private float timeCounter;

    PanelManager PanelManager;


    private void Start()
    {
        PanelManager = FindObjectOfType<PanelManager>();
        timeCounter = time;
        transform.GetComponent<Button>().onClick.AddListener(() => buttonCloseNotif());
        transform.parent.GetComponent<Button>().onClick.AddListener(() => buttonOpenPesanMasuk());
    }
    private void Update()
    {
        timeCounter -= 1f * Time.deltaTime;

        if (timeCounter <= 0)
        {
            buttonCloseNotif();
        }
    }
    public void buttonCloseNotif()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public void buttonOpenPesanMasuk()
    {

        PanelManager.menu5();
    }

}
