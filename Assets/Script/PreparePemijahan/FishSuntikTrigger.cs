using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FishSuntikTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tersuntikText;
    [SerializeField] private GameObject tanganPegangIkan, suntikGaming;
    [SerializeField] private RectTransform suntikArea, suntikNonArea1, suntikNonArea2;
    [SerializeField] private GameObject ikanBerita1, ikanBetina2, ikanJantan;
    //[SerializeField] private GameObject suntikan;
    private Button suntikJantanBtn, suntikBetinaBtn;

    public bool isTimeRunning;
    public bool isSiapPijah, isTerpijah;
    private float delayPijah = 8f, currentDelayPijah;

    private void Start()
    {
        //suntikJantanBtn = GameObject.Find("Suntik Jantan").GetComponent<Button>();
        //suntikBetinaBtn = GameObject.Find("Suntik Betina").GetComponent<Button>();

        isTimeRunning = false;
        isSiapPijah = false;
        isTerpijah = false;

        currentDelayPijah = delayPijah;

        tanganPegangIkan.SetActive(false);
        suntikGaming.SetActive(false);
        suntikArea.gameObject.SetActive(false);

        //suntikan.SetActive(false);
    }

    private void Update()
    {
        if(isTimeRunning == true)
        {
            currentDelayPijah -= 1f * Time.deltaTime;
            tersuntikText.SetText("Menunggu dalam " + currentDelayPijah.ToString("0") + " jam");

            if(currentDelayPijah <= 0f)
            {
                tersuntikText.SetText("Siap Dipijah!");
                isTimeRunning = false;
                currentDelayPijah = delayPijah;

                isSiapPijah = true;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Dalam Proses Suntik");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        ikanJantan.SetActive(false);
        ikanBerita1.SetActive(false);
        ikanBetina2.SetActive(false);

        tanganPegangIkan.SetActive(true);
        suntikGaming.SetActive(true);
        suntikArea.gameObject.SetActive(true);

        suntikNonArea1.anchoredPosition = new Vector2(suntikNonArea1.anchoredPosition.x + 2000, suntikNonArea1.anchoredPosition.y + 2000);
        suntikNonArea2.anchoredPosition = new Vector2(suntikNonArea2.anchoredPosition.x + 2000, suntikNonArea2.anchoredPosition.y + 2000);

        //isTimeRunning = true;
        //isTerpijah = true;
    }
}
