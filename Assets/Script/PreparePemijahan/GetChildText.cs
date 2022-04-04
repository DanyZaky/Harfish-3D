using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetChildText : MonoBehaviour
{
    public GameObject textDuration;
    void Start()
    {
        textDuration = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        Debug.Log(textDuration.GetComponent<TextMeshProUGUI>());
    }
}
