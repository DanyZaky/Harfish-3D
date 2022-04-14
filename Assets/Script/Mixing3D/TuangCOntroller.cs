using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TuangCOntroller : MonoBehaviour
{
    [SerializeField] GameObject bowl;
    [SerializeField] Slider tuangSlider;

    private float rotateValue, rotateZ;
    void Start()
    {
        
        
        
    }
    void Update()
    {
        bowl.transform.rotation = Quaternion.Euler(0, 0, rotateZ);

        rotateZ = tuangSlider.value * -180;

        Debug.Log(tuangSlider.value);
    }
}
