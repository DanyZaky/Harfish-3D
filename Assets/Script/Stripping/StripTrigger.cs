using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StripTrigger : MonoBehaviour
{
    PowerBar pb;

    private float jumlahTelur;
    [SerializeField] private float maxJumlahTelur;
    [SerializeField] private Image progressBar;

    [SerializeField] private TextMeshProUGUI jumalhTelurText, countdownText;
    [SerializeField] private GameObject delayStripping, prefabsSelTelur;

    [SerializeField] private float countDown;
    private float countDownCounter;

    void Start()
    {
        pb = GameObject.Find("PowerBar").GetComponent<PowerBar>();
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = false;

        jumlahTelur = 0f;
        progressBar.fillAmount = 0;

        countDownCounter = countDown;
    }

    void Update()
    {
        WinLoseCondition();

        CountDown();
    }

    private void OnMouseDown()
    {
        Instantiate(prefabsSelTelur, new Vector3(-1.65f, -0.53f, -7.54f), Quaternion.identity);
        
        pb.isPowerRunning = false;
        jumlahTelur += Random.Range(50.0f,52.3f);
        jumalhTelurText.SetText("Jumlah Telur : " + jumlahTelur.ToString(".0") + "ml");
        progressBar.fillAmount = jumlahTelur / maxJumlahTelur;
        StartCoroutine(strippingAnimation());
    }

    private IEnumerator strippingAnimation()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = true;

        yield return new WaitForSeconds(5);
        
        pb.isPowerRunning = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void WinLoseCondition()
    {
        if (jumlahTelur >= maxJumlahTelur)
        {
            Debug.Log("Win");
        }
    }

    private void CountDown()
    {
        countDownCounter -= 1f * Time.deltaTime;
        countdownText.SetText(countDownCounter.ToString("0"));

        if (countDownCounter <= 0f)
        {
            Debug.Log("Lose");
        }
    }
}
