using System.Collections;
using UnityEngine;

/// <summary>
/// Player shooter component: Every object with this component will
/// launch a defined projectile object. There is a reload timer, that
/// will ensure this projectile cannot be abused.
/// 
/// This is used for the Plasma Shot and the Missile Shot.
/// </summary>
public class PlayerShooter : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The projectile.
	/// </summary>
	public Transform Shot;
	/// <summary>
	/// Projectile spawn position.
	/// </summary>
	public Transform SpawnPosition;
	/// <summary>
	/// The reload time before the shot can be used again.
	/// </summary>
	public float ReloadTime;
	/// <summary>
	/// The button used to shot.
	/// </summary>
	public string ShootButton = "Jump";
	#endregion Public Attributes

	#region Private Attributes
	/// <summary>
	/// Can the player fire?
	/// </summary>
	private bool _canFire = true;
	#endregion Private Attributes

	/// <summary>
	/// Checks if the player can fire and the fire button is pressed.
	/// If positive for both, launches a instance of the projectile.
	/// </summary>
	void Update () 
	{
		if (!_canFire) return;
		if (!Input.GetButton(ShootButton)) return;

		_canFire = false;
		StartCoroutine(ReloadTimer());
		Instantiate(Shot, SpawnPosition.position, Quaternion.identity);
	}

	/// <summary>
	/// Waits a defined time and enables the player to shot again.
	/// </summary>
	/// <returns>The wait time.</returns>
	private IEnumerator ReloadTimer() 
	{
		yield return new WaitForSeconds(ReloadTime);
		_canFire = true;
	}
}
