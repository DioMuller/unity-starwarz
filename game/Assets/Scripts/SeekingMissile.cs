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

	/// <summary>
	/// Will the missile seek a fixed target? (The last spawned
	/// item after awake), or always the last spawn item?
	/// </summary>
	public bool fixedTarget = false;
	#endregion Public Attributes

	#region Private Attributes
	public Transform target = null; 
	#endregion Private Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes the target, if it is fixed.
	/// </summary>
	void Awake ()
	{
		if( !fixedTarget || Game.Data.LatestNPCs.Count == 0 ) return;

		target = Game.Data.LatestNPCs[0];
	}

	/// <summary>
	/// Rotates the object to the target's position.
	/// </summary>
	void Update ()
	{
		if (Game.Data.LatestNPCs.Count == 0) return; // No target to follow.

		if( !fixedTarget ) target = Game.Data.LatestNPCs[0]; // Not Fixed, will update with the newest.

		if( target == null ) return; // Was Destroyed.

		var dT = Time.deltaTime;

		var current = transform.rotation; // Stores Current location
		transform.LookAt (target); // Obtains desired location
		var rotated = transform.rotation; // Stores desired location

		// Rotates Towards the desired location.
		transform.rotation = Quaternion.RotateTowards (current, rotated, rotateSpeed * dT);
	}
	#endregion MonoBehaviour Methods
}
