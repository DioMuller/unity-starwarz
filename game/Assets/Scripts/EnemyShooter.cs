using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy shooter component: Makes the gameObject shoot another object, at a defined time interval.
/// </summary>
public class EnemyShooter : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The enemy shot transform.
	/// </summary>
	public Transform EnemyShot;
	/// <summary>
	/// The enemy shot spawn position
	/// </summary>
	public Transform EnemyShotSpawnPosition;
	/// <summary>
	/// The reload time between each shot.
	/// </summary>
	public float ReloadTime = 3.0f;
	#endregion Public Attributes

	#region MonoBehavior Methods
	/// <summary>
	/// On wake, this will Invoke Repeating the Shoot method, at each ReloadTime seconds,
	/// starting on a random time between 0 and ReloadTime.
	/// </summary>
	void Awake() 
	{
		// First shot will be fired in a random time between 0 and Reload Time.
		float start = Random.Range(0.0f, ReloadTime);

		InvokeRepeating("Shoot", start, ReloadTime);
	}
	#endregion MonoBehavior Methods

	#region Public Methods
	/// <summary>
	/// Shoots the projectile.
	/// </summary>
	private void Shoot() 
	{
		Instantiate(EnemyShot, EnemyShotSpawnPosition.position, Quaternion.identity);
	}
	#endregion Public Methods
}
