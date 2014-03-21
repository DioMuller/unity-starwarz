using UnityEngine;
using System.Collections;

/// <summary>
/// Player lives event: Implements the WasHit message for
/// the player.
/// </summary>
public class PlayerHit : MonoBehaviour 
{
	#region Private Attributes
	/// <summary>
	/// Time the player ship is invincible.
	/// </summary>
	public float invincibleTimer = 3.0f;

	/// <summary>
	/// Interval between blinks.
	/// </summary>
	public float blinkInterval = 0.5f;

	public Transform shipObject;
	#endregion Private Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Starts the repeated invoking of BlinkAndDecrement.
	/// </summary>
	public void Awake()
	{
		InvokeRepeating("BlinkAndDecrement", blinkInterval, blinkInterval);
	}
	#endregion MonoBehaviour Methods

	#region Message Implementations
	/// <summary>
	/// WasHit message for the player.
	/// Decreases lives and creates an explosion effect.
	/// </summary>
    public void WasHit()
    {
		// Even if the player is invincible, there will be an explosion.
		// Explosions are awesome!
		Game.Data.CreateExplosion(transform.position);

		if( invincibleTimer > 0.0f ) return;
        Game.Data.DecreaseLives(1);

		Destroy(gameObject);
    }
	#endregion Message Implementations

	#region Invokes
	/// <summary>
	/// Blinks the ship and decrements the invincible timer.
	/// </summary>
	private void BlinkAndDecrement()
	{
		if( shipObject != null ) shipObject.renderer.enabled = !shipObject.renderer.enabled;
		invincibleTimer -= blinkInterval;

		if( invincibleTimer > 0.0f ) return;

		CancelInvoke("BlinkAndDecrement");
		if( shipObject != null ) shipObject.renderer.enabled = true;
	}
	#endregion Invokes
}
