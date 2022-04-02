using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StripTrigger : MonoBehaviour
{
    PowerBar pb;

    private float jumlahTelur;
    [SerializeField] private TextMeshProUGUI jumalhTelurText;

    void Start()
    {
        pb = GameObject.Find("PowerBar").GetComponent<PowerBar>();

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

        yield return new WaitForSeconds(5);
        
        pb.isPowerRunning = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
