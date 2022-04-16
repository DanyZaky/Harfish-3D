using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedMixing : MonoBehaviour
{
    Vector3 PreviousFramePosition = Vector3.zero;
    public float speed = 0f;

    [SerializeField] private TextMeshProUGUI telurTeraduk;
    [SerializeField] private Image progressTeraduk;
    [SerializeField] private JumlahTelur jt;

    private float telurTeradukCount;

    private void Start()
    {
        progressTeraduk.fillAmount = 0;
    }

    void Update()
    {
        float movementPerFrame = Vector3.Distance(PreviousFramePosition, transform.position);
        speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;

        ProgressTelurTeraduk();
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
            telurTeradukCount += 1f * Time.deltaTime;
            telurTeraduk.SetText(telurTeradukCount.ToString("0"));
            progressTeraduk.fillAmount = telurTeradukCount / jt.jmlTelur;
        }

        if (telurTeradukCount >= jt.jmlTelur)
        {
            telurTeradukCount = jt.jmlTelur;
        }
    }
}
