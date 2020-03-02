﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///
///	Detecting what the player is looking at.
///

public class DetectLookatInteractiveObjects : MonoBehaviour
{
	[Tooltip ("Starting point of Raycast")]
	[SerializeField]
	private Transform raycastOrigin;

	[Tooltip("How far from the raycastOrigin we will search for a interative element")]
	[SerializeField]
	private float maxRange = 5.0f;

	private void FixedUpdate()
	{	
		Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
		RaycastHit hitInfo;
		bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

		if(objectWasDetected)
		{
			Debug.Log("Player is looking at: " + hitInfo.collider.gameObject.name);
		}
	}
}
