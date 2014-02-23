﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public Vector3 Offset;

// 	// Use this for initialization
// 	void Start () {
// 	
// 	}
	
	void Update () {
		var dT = Time.deltaTime;
		transform.Translate(Offset * dT);
	}
}
