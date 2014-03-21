using UnityEngine;
using System.Collections;

/// <summary>
/// Seeking missile component: Makes the object follow another object.
/// In this case, it's always the last spawned NPC.
/// </summary>
public class SeekingMissile : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The rotation speed (Euler).
	/// </summary>
	public float rotateSpeed;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Rotates the object to the target's position.
	/// </summary>
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
	#endregion MonoBehaviour Methods
}
