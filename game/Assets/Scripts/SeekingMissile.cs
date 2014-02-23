using UnityEngine;
using System.Collections;

public class SeekingMissile : MonoBehaviour 
{
	public float rotateSpeed;
	
	// Update is called once per frame
	void Update ()
	{
		if (Game.Data.latestNPC != null) 
		{
			var dT = Time.deltaTime;

			var current = transform.rotation;
			transform.LookAt (Game.Data.latestNPC);
			var rotated = transform.rotation;

			transform.rotation = Quaternion.RotateTowards (
			current, rotated, rotateSpeed * dT);
		}
	}
}
