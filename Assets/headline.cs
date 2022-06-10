using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class headline : MonoBehaviour
{
    float speed = 200;
    //float textposbegin = 100000000000000.0f;
    float boundarytextend = -3000.0f;
    // Start is called before the first frame update

    RectTransform uy;
    [SerializeField]
    TextMeshProUGUI pesan;
    [SerializeField]
    bool isLooping = false;
    void Start()
    {
        uy = gameObject.GetComponent<RectTransform>();
        StartCoroutine(autoscrolltext());

    }
    IEnumerator autoscrolltext()
    {
        while (uy.localPosition.x > boundarytextend)
        {
            uy.Translate(Vector3.left * speed * Time.deltaTime);
            if (uy.localPosition.x < boundarytextend)
            {
                if (isLooping)
                {
                    uy.localPosition = Vector3.left * boundarytextend;

                }
                else
                {
                    Debug.Log("lho he");
                    break;

                }
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
