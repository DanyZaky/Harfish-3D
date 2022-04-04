using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop2 : MonoBehaviour
{
bool isDragable = true;
bool isDragged = false;

    void Update() {
        if(isDragged){
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }        
    }

    private void OnMouseOver() {
        if(isDragable && Input.GetMouseButtonDown(0)){
            isDragged = true;
        }
    }

    private void OnMouseUp() {
        isDragged = false;    
    }

}
