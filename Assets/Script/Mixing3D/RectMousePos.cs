using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectMousePos : MonoBehaviour
{
    private void Update()
    {
        moveObj();
    }

    public void moveObj()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
    }
}
