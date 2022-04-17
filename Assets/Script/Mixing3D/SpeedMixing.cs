using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SpeedMixing : MonoBehaviour
{
    Vector3 PreviousFramePosition = Vector3.zero;
    public float speed = 0f;

    [SerializeField] private TextMeshProUGUI telurTeraduk, countdown, scoreMixing;
    [SerializeField] private Image progressTeraduk;
    [SerializeField] private JumlahTelur jt;
    [SerializeField] private GameObject winPanel, telurPrefabs, spermaPrefabs;

    [SerializeField] private float cd;

    [SerializeField] private CanvasGroup tutorPanel1, tutorPanel2, tutorPanel3;
    private float currentCD;
    private bool isGameOver;

    private float telurTeradukCount;

    private bool isWin, isMixing;

    Vector3 spermPos = new Vector3(0.222f, 1.627f, -8.5852f);
    Vector3 telurPos = new Vector3(-0.1901f, 1.627f, -8.5852f);

    private void Start()
    {
        progressTeraduk.fillAmount = 0;

        currentCD = cd;
        isGameOver = true;

        winPanel.SetActive(false);
        isWin = true;

        isMixing = false;

        //Debug.Log("telur = " + PlayerPrefs.GetFloat("TelurCount").ToString("0") + "|| sperma = " + PlayerPrefs.GetFloat("SpermaCount").ToString("0"));

        for (int i = 0; i < ((int)(PlayerPrefs.GetFloat("SpermaCount") / 10)); i++)
        {
            Instantiate(spermaPrefabs, spermPos, Quaternion.identity);
        }

        for (int i = 0; i < ((int)(PlayerPrefs.GetFloat("TelurCount") / 20)); i++)
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
    }

    public float GetMoveSpeed()
    {
        return speed;
    }

    private void ProgressTelurTeraduk()
    {
        progressTeraduk.fillAmount = telurTeradukCount / jt.jmlTelur;

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

        if (telurTeradukCount >= jt.jmlTelur)
        {
            telurTeradukCount = jt.jmlTelur;
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

                PlayerPrefs.SetFloat("MixingCount", telurTeradukCount);
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
