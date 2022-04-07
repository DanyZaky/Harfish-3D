using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddropvideo1 : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public GameObject feather;

    private void Start()
    {
        feather.SetActive(false);
    }
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // pixel coordinates (x,y)
        Vector3 mousePoint = Input.mousePosition;        
        // z coordinate of game object on screen
        
        mousePoint.z = mZCoord;

        // Convert it to world points
        if (mousePoint.y <= 0f)
        {
            mousePoint.y = 0.1f;
        }
       return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        feather.SetActive(true);
    }
    void OnMouseUp()
    {
        feather.SetActive(false);
    }

}
