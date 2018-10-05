using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceCursor : MonoBehaviour
{
	Transform cacheTransform;
	public float adjustZ;

	void Start()
	{
		cacheTransform = this.transform;

		//hide original cursor
		Cursor.visible = false;
	}

	void Update()
	{
		//copy Input.mousePosition into mousePos
		Vector3 mousePos = Input.mousePosition;
		//adjust z distance
		mousePos.z = adjustZ;
		//convert screenspace to world space
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		//paste to "this"
		cacheTransform.position = mousePos; // <--- note that I use .position here instead of .localPosition
	}
}
