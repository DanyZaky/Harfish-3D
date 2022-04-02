using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StripTrigger : MonoBehaviour
{
    PowerBar pb;

    private float jumlahTelur;
    [SerializeField] private TextMeshProUGUI jumalhTelurText;
    [SerializeField] private GameObject delayStripping;

    void Start()
    {
        pb = GameObject.Find("PowerBar").GetComponent<PowerBar>();
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        delayStripping.GetComponent<PolygonCollider2D>().enabled = false;

        jumlahTelur = 0f;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        pb.isPowerRunning = false;
        jumlahTelur += 1f;
        jumalhTelurText.SetText(jumlahTelur.ToString("0"));
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
}
