﻿using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {


		

	public Camera _setCamera;

	//Margin
	float margin = 0.01f;  
	float negativeMargin;
	float positiveMargin;

	void Start ()
	{
		if (_setCamera == null) {
			_setCamera = Camera.main;
		}

		negativeMargin = 0 - margin;
		positiveMargin = 1 + margin;
	}

	// Update is called once per frame
	void Update () 
	{
		if (this.isOutOfScreen()) {
			Destroy (gameObject);
		}
	}

	bool isOutOfScreen() 
	{
		Vector3 positionInScreen = _setCamera.WorldToViewportPoint(transform.position);
		positionInScreen.z = transform.position.z;

		if (positionInScreen.x <= negativeMargin ||
			positionInScreen.x >= positiveMargin ||
			positionInScreen.y <= negativeMargin
			)
		{
			return true;
		} else {
			return false;
		}
	}
}
	 


	

