using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class StripTrigger : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public Vector3 startPosition;

    PowerBar pb;

    private float jumlahTelur;
    [SerializeField] private float maxJumlahTelur;
    [SerializeField] private Image progressBar;

    [SerializeField] private TextMeshProUGUI jumalhTelurText, countdownText, currentScore;
    [SerializeField] private GameObject delayStripping, prefabsSelTelur, winPanel, losePanel, filledBowl;
    [SerializeField] private DialogueStripping ds;

    [SerializeField] private float countDown;
    [SerializeField] private Animator handAnim, fishAnim;
    private float countDownCounter;
    private bool isGameOver;

    //[SerializeField] private CanvasGroup panelTutorial1, panelTutorial2, panelTutorial3, panelTutorial4;
    //public bool isTutorial;
    [SerializeField]private bool isWin;

    [SerializeField] private float moveFilledBowl;
    [SerializeField] private float selCount;
    [SerializeField] private string nameValue;

    [SerializeField] private string animStrip, animIdle, animMarah;

    void Start()
    {
        pb = GameObject.Find("PowerBar").GetComponent<PowerBar>();
        delayStripping.GetComponent<MeshCollider>().enabled = false;

        jumlahTelur = 0f;
        progressBar.fillAmount = 0;

        countDownCounter = countDown;
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        isGameOver = true;
        //gameObject.GetComponent<MeshCollider>().enabled = false;

        //isTutorial = true;
        isWin = true;
    }

    void Update()
    {
        WinLoseCondition();

        CountDown();

        if (ds.startTutorial == true)
        {
            isGameOver = false;
        }
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;

    }
    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }
    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        transform.position = startPosition;

        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            transform.position = startPosition;
            if (hitInfo.transform.tag == destinationTag)
            {
                transform.position = hitInfo.transform.position;
                Debug.Log("hit");
                transform.position = startPosition;

                if (pb.powerCountCounter <= 130f && pb.powerCountCounter >= -130f)
                {
                    pb.isPowerRunning = false;
                    filledBowl.transform.position -= new Vector3(0f, 0f, moveFilledBowl);
                    jumlahTelur += (Random.Range(0.5f, 2.3f) + selCount);
                    jumalhTelurText.SetText(jumlahTelur.ToString("0"));
                    progressBar.fillAmount = jumlahTelur / maxJumlahTelur;
                    StartCoroutine(strippingAnimation(handAnim, animStrip, animIdle, new Vector3(0.28f, 0.76f, -7.54f), 0.25f, 2.0f));
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                    /*
                    if (isTutorial == true)
                    {
                        gameObject.GetComponent<MeshCollider>().enabled = false;
                        isTutorial = false;
                        StartCoroutine(FadeIn(panelTutorial3, 0.4f));
                    }*/

                    ds.startTutorial = false;
                }

                if (pb.powerCountCounter > 130f || pb.powerCountCounter < -130f)
                {
                    Debug.Log("Marah");

                    pb.isPowerRunning = false;
                    StartCoroutine(marahAnimation());
                }
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private IEnumerator strippingAnimation(Animator gameobj ,string anim1, string anim2, Vector3 pos, float dur1, float dur2)
    {
        gameobj.Play(anim1);
        gameObject.GetComponent<MeshCollider>().enabled = false;
        delayStripping.GetComponent<MeshCollider>().enabled = true;
        gameObject.transform.position = new Vector3(99f, 99f, 99f);

        yield return new WaitForSeconds(dur1);

        Instantiate(prefabsSelTelur, pos, Quaternion.Euler(-90f, 0f, 0f));
        SoundManager.Instance.PlaySFX("SFX Mixing");

        yield return new WaitForSeconds(dur2);

        gameobj.Play(anim2);
        pb.isPowerRunning = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.transform.position = startPosition;
        delayStripping.GetComponent<MeshCollider>().enabled = false;
    }

    private IEnumerator marahAnimation()
    {
        handAnim.Play(animStrip);
        
        gameObject.GetComponent<MeshCollider>().enabled = false;
        delayStripping.GetComponent<MeshCollider>().enabled = true;
        gameObject.transform.position = new Vector3(99f, 99f, 99f);

        yield return new WaitForSeconds(0.7f);

        SoundManager.Instance.PlaySFX("SFX Angry");
        handAnim.Play(animMarah);

        yield return new WaitForSeconds(1.7f);

        handAnim.Play(animIdle);
        fishAnim.Play("idlefish");
        pb.isPowerRunning = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
        gameObject.transform.position = startPosition;
        delayStripping.GetComponent<MeshCollider>().enabled = false;
    }

    private void WinLoseCondition()
    {
        //WIN
        if (jumlahTelur >= maxJumlahTelur)
        {
            if(isWin)
            {
                SoundManager.Instance.PlaySFX("SFX Win");
                isWin = false;
            }
            
            winPanel.SetActive(true);
            
            isGameOver = true;
            pb.isPowerRunning = false;
            gameObject.GetComponent<MeshCollider>().enabled = false;
            PlayerPrefs.SetFloat(nameValue, jumlahTelur);
            currentScore.SetText(PlayerPrefs.GetFloat(nameValue).ToString("0"));
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
            winPanel.SetActive(true);
            if (isWin)
            {
                SoundManager.Instance.PlaySFX("SFX Win");
                isWin = false;
            }
            gameObject.GetComponent<MeshCollider>().enabled = false;
            PlayerPrefs.SetFloat(nameValue, jumlahTelur);
            currentScore.SetText(PlayerPrefs.GetFloat(nameValue).ToString("0"));
        }
    }
    /*
    public void buttonTutorial1()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(SmoothFadeTransition(panelTutorial1, panelTutorial2, 0.4f));
    }

    public void buttonTutorial2()
    {
        SoundManager.Instance.PlaySFX("SFX Button");
        StartCoroutine(FadeOut(panelTutorial2, 0.4f));
        //gameObject.GetComponent<MeshCollider>().enabled = true;
        //isGameOver = false;
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
        //gameObject.GetComponent<MeshCollider>().enabled = true;
    }*/

    public IEnumerator FadeIn(CanvasGroup container, float duration)
    {
        //container.interactable = false;
        container.gameObject.SetActive(true);
        container.alpha = 0f;
        yield return new WaitForSeconds(0);
        //container.DOFade(1f, duration).SetUpdate(true);
        //container.interactable = true;
    }

    public IEnumerator FadeOut(CanvasGroup container, float duration)
    {
        //container.interactable = false;
        container.alpha = 1f;
        //container.DOFade(0f, duration).SetEase(Ease.InQuint).SetUpdate(true);
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
