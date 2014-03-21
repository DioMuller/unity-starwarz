using UnityEngine;
using System.Collections;

/// <summary>
/// Player lives event: Implements the WasHit message for
/// the player.
/// </summary>
public class PlayerLives : MonoBehaviour 
{
	#region Message Implementations
	/// <summary>
	/// WasHit message for the player.
	/// Decreases lives and creates an explosion effect.
	/// </summary>
    public void WasHit()
    {
        Game.Data.DecreaseLives(1);
		Game.Data.CreateExplosion(transform.position);

		Destroy(gameObject);
    }
	#endregion Message Implementations
}
