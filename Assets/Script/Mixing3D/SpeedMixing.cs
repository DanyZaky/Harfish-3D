using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SpeedMixing : MonoBehaviour
{
    [SerializeField] private IkanVariable iv;
    
    Vector3 PreviousFramePosition = Vector3.zero;
    public float speed = 0f;

    [SerializeField] private TextMeshProUGUI telurTeraduk, countdown, scoreMixing;
    [SerializeField] private Image progressTeraduk;
    [SerializeField] private JumlahTelur jt;
    [SerializeField] private GameObject winPanel, telurPrefabs, spermaPrefabs, losePanel;
    [SerializeField] private CountInBowl cibTelur, cibSperma;

    private float cd;

    [SerializeField] private CanvasGroup tutorPanel1, tutorPanel2, tutorPanel3;

    [SerializeField] private DialogueStripping ds;
    private float currentCD;
    private bool isGameOver;

    [HideInInspector] public float telurTeradukCount;

    private bool isWin, isMixing;
    public bool isAdaSelSperma;

    Vector3 spermPos = new Vector3(0.222f, 1.627f, -8.5852f);
    Vector3 telurPos = new Vector3(-0.1901f, 1.627f, -8.5852f);

    [SerializeField] private string nameSpermaCount, nameTelurCount, mixingCount;

    private void Start()
    {
        progressTeraduk.fillAmount = 0;

        cd = iv.TimerMixing;

        currentCD = cd;
        isGameOver = true;

        winPanel.SetActive(false);
        losePanel.SetActive(false);
        isWin = true;

        isMixing = false;
        isAdaSelSperma = false;

        //Debug.Log("telur = " + PlayerPrefs.GetFloat("TelurCount").ToString("0") + "|| sperma = " + PlayerPrefs.GetFloat("SpermaCount").ToString("0"));

        for (int i = 0; i < ((int)(PlayerPrefs.GetFloat(nameSpermaCount) / 10)); i++)
        {
            Instantiate(spermaPrefabs, spermPos, Quaternion.identity);
        }

        for (int i = 0; i < ((int)(PlayerPrefs.GetFloat(nameTelurCount) / 20)); i++)
        {
            Instantiate(telurPrefabs, telurPos, Quaternion.identity);
        }
    }

    void Update()
    {
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;

        ProgressTelurTeraduk();
        Countdown();

        if(ds.startTutorial == true)
        {
            isGameOver = false;
        }
    }

    public float GetMoveSpeed()
    {
        return speed;
    }

    private void ProgressTelurTeraduk()
    {
        progressTeraduk.fillAmount = telurTeradukCount / jt.jmlTelur;

        if(isAdaSelSperma == true && cibTelur.isAbis == true)
        {
            if (speed >= 1f)
            {
                telurTeradukCount += Random.Range(19f, 25f) * Time.deltaTime;
                telurTeraduk.SetText(telurTeradukCount.ToString("0"));
                //SoundManager.Instance.PlaySFX("SFX Mixing");
                progressTeraduk.fillAmount = telurTeradukCount / jt.jmlTelur;

                isMixing = true;
                Debug.Log("ismixing");
            }

            if (speed < 1f)
            {
                isMixing = false;
            }
        }

        if (telurTeradukCount >= jt.jmlTelur)
        {
            telurTeradukCount = jt.jmlTelur;
        }
        //condition
        if(telurTeradukCount == jt.jmlTelur && telurTeradukCount > 1)
        {
            currentCD = 0f;
        }

        if(cibTelur.isAbis == true && cibSperma.isAbis == true && jt.jmlTelur <= 0)
        {
            losePanel.SetActive(true);
            winPanel.SetActive(false);
            isGameOver = false;
        }
    }

    private void Countdown()
    {
        if(isGameOver == false)
        {
            currentCD -= 1f * Time.deltaTime;
            countdown.SetText(currentCD.ToString("0"));

            //gameover
            if (currentCD <= 0f)
            {
                currentCD = 0;
                countdown.SetText(currentCD.ToString("0"));
                isGameOver = true;
                if (isWin)
                {
                    SoundManager.Instance.PlaySFX("SFX Win");
                    isWin = false;
                }

                scoreMixing.SetText(telurTeradukCount.ToString("0"));
                winPanel.SetActive(true);

                PlayerPrefs.SetFloat(mixingCount, telurTeradukCount);
            }
        }
    }

    public void buttonTutorial1()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(SmoothFadeTransition(tutorPanel1, tutorPanel2, 0.4f));
    }

    public void buttonTutorial2()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(SmoothFadeTransition(tutorPanel2, tutorPanel3, 0.4f));
    }

    public void buttonTutorial3()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(FadeOut(tutorPanel3, 0.4f));
        isGameOver = false;
    }

    public IEnumerator FadeIn(CanvasGroup container, float duration)
    {
        //container.interactable = false;
        container.gameObject.SetActive(true);
        container.alpha = 0f;
        yield return new WaitForSeconds(0);
        container.DOFade(1f, duration).SetUpdate(true);
        //container.interactable = true;
    }

    public IEnumerator FadeOut(CanvasGroup container, float duration)
    {
        //container.interactable = false;
        container.alpha = 1f;
        container.DOFade(0f, duration).SetEase(Ease.InQuint).SetUpdate(true);
        yield return new WaitForSecondsRealtime(duration);
        container.gameObject.SetActive(false);
        //container.interactable = true;
    }

    public IEnumerator SmoothFadeTransition(CanvasGroup panel1, CanvasGroup panel2, float duration)
    {
        StartCoroutine(FadeOut(panel1, duration));
        yield return new WaitForSecondsRealtime(duration);
        StartCoroutine(FadeIn(panel2, duration));
    }
}
