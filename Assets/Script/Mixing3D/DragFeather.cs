using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFeather : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		Debug.Log("test");
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		transform.position = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		Debug.Log("testttttttttttt");
	}
}
