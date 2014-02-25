using UnityEngine;
using System.Collections;

public class SeekingMissile : MonoBehaviour 
{
	public float rotateSpeed;
	
	// Update is called once per frame
	void Update ()
	{
		if (Game.Data.LatestNPCs.Count != 0) 
		{
			var dT = Time.deltaTime;

			var current = transform.rotation;
			transform.LookAt (Game.Data.LatestNPCs[0]);
			var rotated = transform.rotation;

			transform.rotation = Quaternion.RotateTowards (
			current, rotated, rotateSpeed * dT);
		}
	}
}
