using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardHandler : MonoBehaviour
{
    private int currentPosition;
    private bool hias, konsumsi;
    [SerializeField] Text namaIkanTextBox;
    [SerializeField] GameObject parentIkan, gambarIkanObject;
    //[SerializeField] GameObject[] menu;
    [SerializeField] string[] namaIkan;
    [SerializeField] Sprite[] gambarIkan,gambarStep;
    [SerializeField] float[] posisiGambarIkan;

    void Start()
    {
        currentPosition = 0;
        Change();
    }

    private void Change()
    {
        gambarIkanObject.GetComponent<Image>().sprite = gambarIkan[currentPosition];
        gambarIkanObject.GetComponent<RectTransform>().position = new Vector3 (posisiGambarIkan[currentPosition], 0,0);
        namaIkanTextBox.text = namaIkan[currentPosition].ToUpper();
        parentIkan.transform.GetChild(currentPosition).GetComponent<Image>().sprite = gambarStep[1];
        parentIkan.transform.GetChild(currentPosition).GetComponent<RectTransform>().sizeDelta = new Vector2(40,40);
        
    }
    public void Next()
    {
        currentPosition++;
        parentIkan.transform.GetChild(currentPosition-1).GetComponent<Image>().sprite = gambarStep[0];
        parentIkan.transform.GetChild(currentPosition-1).GetComponent<RectTransform>().sizeDelta = new Vector2(20,20);
        if(hias)
            if(currentPosition >= 14) currentPosition = 0;  
        if(konsumsi)
            if(currentPosition >= 6) currentPosition = 0;
        Change();
    }

    public void Back()
    {
        currentPosition--;
        parentIkan.transform.GetChild(currentPosition+1).GetComponent<RectTransform>().sizeDelta = new Vector2(20,20);
        parentIkan.transform.GetChild(currentPosition+1).GetComponent<Image>().sprite = gambarStep[0];
        if(hias)
            if(currentPosition <= -1) currentPosition = 13;
        if(konsumsi)
            if(currentPosition <= -1) currentPosition = 5;
        Change();
    }

    

    // public void Return()
    // {
    //     menu[0].SetActive(true);
    //     if(hias)
    //     {
    //         menu[1].SetActive(false);
    //         hias = false;
    //     }
    //     if(konsumsi)
    //     {
    //         menu[2].SetActive(false);
    //         konsumsi = false;
    //     }
    // }

    public void Hias()
    {
        hias = true;
    }

    public void Konsumsi()
    {
        konsumsi = true;
    }


}
