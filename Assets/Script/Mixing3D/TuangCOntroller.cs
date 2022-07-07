using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuangCOntroller : MonoBehaviour
{
    [SerializeField] GameObject bowl;
    [HideInInspector] public float tuangValue;
    [SerializeField] private float tuangValueCounter;
    [SerializeField] private PowerBarMixing pbm;
    [SerializeField] private GameObject pembatasMangkok1, pembatasMangkok2;
    private float rotateZ;

    private bool isTuang;

    private void Start()
    {
        isTuang = false;
    }

    private void Update()
    {
        if (pbm.powerCountCounter < 100f && pbm.powerCountCounter > -100)
        {
            tuangValue = 5;
        }

        if (pbm.powerCountCounter < 220 && pbm.powerCountCounter > 100 || pbm.powerCountCounter > -220 && pbm.powerCountCounter < -100)
        {
            tuangValue = 10;
        }

        if (pbm.powerCountCounter > 220 || pbm.powerCountCounter < -220)
        {
            tuangValue = 20;
        }
    }

    private void FixedUpdate()
    {
        if(isTuang == true)
        {
            rotateZ += 1f * tuangValue * tuangValueCounter;

            bowl.transform.rotation = Quaternion.Euler(0, 0, rotateZ);

            Debug.Log("nilai: " + rotateZ.ToString("0"));

            pembatasMangkok1.SetActive(false);
            pembatasMangkok2.SetActive(false);
        }
        if(isTuang == false)
        {
            pembatasMangkok1.SetActive(true);
            pembatasMangkok2.SetActive(true);
        }
    }

    public void Tuang(bool _isTuang)
    {
        isTuang = _isTuang;
    }
}
