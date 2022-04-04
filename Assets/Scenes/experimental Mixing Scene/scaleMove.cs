using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleMove : MonoBehaviour
{
    // Start is called before the first frame update
    movementSpeed stirrObj;
    [SerializeField] GameObject maxBar;
    [SerializeField] GameObject minBar;
    float scaleSpeed= 2f;
    float defaultScaleSpeed = 3f;
    void Start()
    {
        stirrObj = GameObject.Find("buat ngaduk").GetComponent<movementSpeed>();
        transform.position = maxBar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float stirrMoveSpeed = stirrObj.GetMoveSpeed();
        if (stirrMoveSpeed <= 0){
            scaleSpeed = defaultScaleSpeed;
            // Debug.Log("true");
            if(transform.position.x <= minBar.transform.position.x){
                scaleSpeed = 0;
            }
            transform.Translate(Vector2.up * scaleSpeed * Time.deltaTime);
        }
        // if speed diatas 10
        // if speed diatas 20
    }
}
