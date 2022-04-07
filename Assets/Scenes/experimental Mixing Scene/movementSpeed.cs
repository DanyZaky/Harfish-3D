using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 PreviousFramePosition = Vector3.zero;
    public float speed = 0f;

    // Update is called once per frame
    void Update()
    {
    float movementPerFrame = Vector3.Distance (PreviousFramePosition, transform.position) ;
     speed = movementPerFrame / Time.deltaTime;
     PreviousFramePosition = transform.position;
    }

    public float GetMoveSpeed(){
        return speed;
    }
}
