using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuangCOntroller : MonoBehaviour
{
    [SerializeField] GameObject bowl;
    [SerializeField] Slider tuangSlider;
    [SerializeField] float maxRotate;
    private float rotateZ;

    void Update()
    {
        bowl.transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        rotateZ = tuangSlider.value * maxRotate;
    }
}
