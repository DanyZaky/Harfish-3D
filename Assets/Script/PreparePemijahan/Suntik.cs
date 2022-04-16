using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Suntik : MonoBehaviour
{
    [SerializeField] private GameObject colIkanJantan, colIkanBetina1, colIkanBetina2, pijahButton, suntikGameobj;
    [SerializeField] private Button suntikJantanBtn, suntikBetinaBtn;
    [SerializeField] private FishSuntikTrigger fstIkanJantan, fstIkanBetina1, fstIkanBetina2;
    void Start()
    {
        colIkanJantan.GetComponent<BoxCollider2D>().enabled = false;
        colIkanBetina1.GetComponent<BoxCollider2D>().enabled = false;
        colIkanBetina2.GetComponent<BoxCollider2D>().enabled = false;

        suntikJantanBtn.interactable = true;
        suntikBetinaBtn.interactable = true;

        pijahButton.SetActive(false);
    }

    void Update()
    {
        if(fstIkanJantan.isSiapPijah == true && fstIkanBetina1.isSiapPijah == true && fstIkanBetina2.isSiapPijah == true)
        {
            SoundManager.Instance.PlaySFX("SFX Win");
            pijahButton.SetActive(true);
        }

        if(fstIkanJantan.isTerpijah == true)
        {
            suntikJantanBtn.interactable = false;
        }

        if(fstIkanBetina1.isTerpijah == true && fstIkanBetina2.isTerpijah == true)
        {
            suntikBetinaBtn.interactable = false;
        }
    }

    public void buttonSuntikJantan()
    {
        colIkanJantan.GetComponent<BoxCollider2D>().enabled = true;
        SoundManager.Instance.PlaySFX("SFX Button");

        suntikJantanBtn.interactable = false;
        suntikBetinaBtn.interactable = false;

        suntikGameobj.SetActive(true);
    }

    public void buttonSuntikBetina()
    {
        colIkanBetina1.GetComponent<BoxCollider2D>().enabled = true;
        colIkanBetina2.GetComponent<BoxCollider2D>().enabled = true;
        SoundManager.Instance.PlaySFX("SFX Button");

        suntikJantanBtn.interactable = false;
        suntikBetinaBtn.interactable = false;

        suntikGameobj.SetActive(true);
    }
}
