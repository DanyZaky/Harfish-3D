using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class StripTrigger : MonoBehaviour
{
    PowerBar pb;

    private float jumlahTelur;
    [SerializeField] private float maxJumlahTelur;
    [SerializeField] private Image progressBar;

    [SerializeField] private TextMeshProUGUI jumalhTelurText, countdownText;
    [SerializeField] private GameObject delayStripping, prefabsSelTelur, winPanel, losePanel, filledBowl;

    [SerializeField] private float countDown;
    [SerializeField] private Animator handAnim, fishAnim;
    private float countDownCounter;
    private bool isGameOver;

    [SerializeField] private CanvasGroup panelTutorial1, panelTutorial2, panelTutorial3, panelTutorial4;
    public bool isTutorial;


    [SerializeField] private float moveFilledBowl;

    void Start()
    {
        pb = GameObject.Find("PowerBar").GetComponent<PowerBar>();
        delayStripping.GetComponent<PolygonCollider2D>().enabled = false;

        jumlahTelur = 0f;
        progressBar.fillAmount = 0;

        countDownCounter = countDown;
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        isGameOver = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        isTutorial = true;
    }

    void Update()
    {
        WinLoseCondition();

        CountDown();
    }

    private void OnMouseDown()
    {
        if (pb.powerCountCounter <= 130f && pb.powerCountCounter >= -130f)
        {
            pb.isPowerRunning = false;
            filledBowl.transform.position -= new Vector3(0f, 0f, moveFilledBowl);
            jumlahTelur += Random.Range(50.0f, 52.3f);
            jumalhTelurText.SetText(jumlahTelur.ToString("0"));
            progressBar.fillAmount = jumlahTelur / maxJumlahTelur;
            StartCoroutine(strippingAnimation(handAnim ,"stripping","idle", new Vector3(-1.67f, -1.64f, -7.54f), 0.5f, 2.0f));
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;

            if (isTutorial == true)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                isTutorial = false;
                StartCoroutine(FadeIn(panelTutorial3, 0.4f));
            }
        }

        if (pb.powerCountCounter > 130f || pb.powerCountCounter < -130f)
        {
            Debug.Log("Marah");
            
            pb.isPowerRunning = false;
            StartCoroutine(marahAnimation());
        }
    }

    private IEnumerator strippingAnimation(Animator gameobj ,string anim1, string anim2, Vector3 pos, float dur1, float dur2)
    {
        gameobj.Play(anim1);
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = true;

        yield return new WaitForSeconds(dur1);

        Instantiate(prefabsSelTelur, pos, Quaternion.Euler(-90f, 0f, 0f));
        SoundManager.Instance.PlaySFX("SFX Mixing");

        yield return new WaitForSeconds(dur2);

        gameobj.Play(anim2);
        pb.isPowerRunning = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private IEnumerator marahAnimation()
    {
        handAnim.Play("stripping");
        
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = true;

        yield return new WaitForSeconds(0.7f);

        SoundManager.Instance.PlaySFX("SFX Angry");
        fishAnim.Play("angryFish");

        yield return new WaitForSeconds(1.7f);

        handAnim.Play("idle");
        fishAnim.Play("idlefish");
        pb.isPowerRunning = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void WinLoseCondition()
    {
        //WIN
        if (jumlahTelur >= maxJumlahTelur)
        {
            SoundManager.Instance.PlaySFX("SFX Win");
            winPanel.SetActive(true);
            
            isGameOver = true;
            pb.isPowerRunning = false;
        }
    }

    private void CountDown()
    {
        if (isGameOver == false)
        {
            countDownCounter -= 1f * Time.deltaTime;
            countdownText.SetText(countDownCounter.ToString("0"));
        }

        //LOSE
        if (countDownCounter <= 0f)
        {
            isGameOver = true;
            pb.isPowerRunning = false;
            losePanel.SetActive(true);
            SoundManager.Instance.PlaySFX("SFX Lose");
        }
    }

    public void buttonTutorial1()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(SmoothFadeTransition(panelTutorial1, panelTutorial2, 0.4f));
    }

    public void buttonTutorial2()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(FadeOut(panelTutorial2, 0.4f));
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        isGameOver = false;
    }

    public void buttonTutorial3()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(SmoothFadeTransition(panelTutorial3, panelTutorial4, 0.4f));
    }

    public void buttonTutorial4()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(FadeOut(panelTutorial4, 0.4f));
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
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
