using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuntikManager : MonoBehaviour
{
    [SerializeField] private GameObject tanganPegangIkan, tanganPegangIkanBetina, suntikGaming, suntikArea1, suntikArea2, suntikArea3, suntikan1, suntikan2, suntikan3, buttonPijah;
    [SerializeField] private FishSuntikTrigger fst1, fst2, fst3;
    public GameObject suntikJantan, suntikBetina1, suntikBetina2, suntikJantanBlack, suntikBetina1Black, suntikBetina2Black;
    Vector2 suntikJantanPos, suntikBetina1Pos, suntikBetina2Pos;
    void Start()
    {
        suntikJantanPos = suntikJantan.transform.position;
        suntikBetina1Pos = suntikBetina1.transform.position;
        suntikBetina2Pos = suntikBetina2.transform.position;

        fst1.isTimeRunning = false;
        fst2.isTimeRunning = false;
        fst3.isTimeRunning = false;
    }

    private void Update()
    {
        if (fst1.isSiapPijah == true && fst2.isSiapPijah == true && fst3.isSiapPijah == true)
        {
            buttonPijah.SetActive(true);
        }
    }

    public void DragSuntikJantan()
    {
        suntikJantan.transform.position = Input.mousePosition;
        suntikJantan.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void DragSuntikBetina1()
    {
        suntikBetina1.transform.position = Input.mousePosition;
        suntikBetina1.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void DragSuntikBetina2()
    {
        suntikBetina2.transform.position = Input.mousePosition;
        suntikBetina2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void DropSuntikJantan()
    {
        float Distance = Vector3.Distance(suntikJantan.transform.position, suntikJantanBlack.transform.position);

        if(Distance < 50f)
        {
            suntikJantan.transform.position = suntikJantanBlack.transform.position;
            SoundManager.Instance.PlaySFX("SFX Inject");

            tanganPegangIkan.SetActive(false);
            suntikGaming.SetActive(false);
            suntikArea1.SetActive(false);
            suntikan1.SetActive(false);

            fst1.isTimeRunning = true;
        }
        else
        {
            suntikJantan.transform.position = suntikJantanPos;
            suntikJantan.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
    }

    public void DropSuntikBetina1()
    {
        float Distance = Vector3.Distance(suntikBetina1.transform.position, suntikBetina1Black.transform.position);

        if (Distance < 50f)
        {
            suntikBetina1.transform.position = suntikBetina1Black.transform.position;
            SoundManager.Instance.PlaySFX("SFX Inject");

            tanganPegangIkanBetina.SetActive(false);
            suntikGaming.SetActive(false);
            suntikArea2.SetActive(false);
            suntikan2.SetActive(false);

            fst2.isTimeRunning = true;
        }
        else
        {
            suntikBetina1.transform.position = suntikBetina1Pos;
            suntikBetina1.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
    }

    public void DropSuntikBetina2()
    {
        float Distance = Vector3.Distance(suntikBetina2.transform.position, suntikBetina2Black.transform.position);

        if (Distance < 50f)
        {
            suntikBetina2.transform.position = suntikBetina2Black.transform.position;
            SoundManager.Instance.PlaySFX("SFX Inject");

            tanganPegangIkanBetina.SetActive(false);
            suntikGaming.SetActive(false);
            suntikArea3.SetActive(false);
            suntikan3.SetActive(false);

            fst3.isTimeRunning = true;
        }
        else
        {
            suntikBetina2.transform.position = suntikBetina2Pos;
            suntikBetina2.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        }
    }
}
