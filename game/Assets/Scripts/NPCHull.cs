using UnityEngine;

/// <summary>
/// NPC hull component: General NPC script. This controls the
/// NPC destruction in case of collision with the player or a
/// projectile, and the NPC respawning in the case the NPC goes
/// out of bounds.
/// </summary>
public class NPCHull : MonoBehaviour 
{
	/// <summary>
	/// Object's original position, for when the object is reseted.
	/// </summary>
	private Vector3 originalpos;

	/// <summary>
	/// Awake will save the object's original position.
	/// </summary>
	public void Awake()
	{
		originalpos = transform.position;
	}

	/// <summary>
	/// Called when the NPC is hit. 
	/// Increases the score, removes from the Latest NPCs list and creates explosion
	/// effect, then removes the object from the scene.
	/// </summary>
	public void WasHit() 
	{
		Game.Data.IncreaseScore(1);
		Game.Data.LatestNPCs.Remove (transform);
		Game.Data.CreateExplosion(transform.position);
		Destroy(gameObject);
	}

	/// <summary>
	/// Destroys the object, after collision.
	/// Used for when the object hits the player.
	/// </summary>
	public void DestroySelfCollision() 
	{
		Game.Data.LatestNPCs.Remove (transform);
        Destroy(gameObject);
		Game.Data.NPCCount--;
	}

	/// <summary>
	/// Used for when the object is destroyed by the "Out of Bounds" objects.
	/// This will make the ship respawn at its original position.
	/// That will make the game progressively harder when the player starts missing
	/// other ships.
	/// </summary>
	public void DestroySelf() 
	{
		// Removes from the Latest NPCs list
		Game.Data.LatestNPCs.Remove (transform);

		// Resets Position
		transform.position = originalpos;
		Game.Data.ShowTeleportEffect(originalpos);

		// Adds to the Latest NPCs list, at the top.
		Game.Data.LatestNPCs.Insert(0, transform);
	}

	/// <summary>
	/// Called when other object colides with this object.
	/// </summary>
	/// <param name="obstacle">Obstacle's collider.</param>
    public void OnTriggerEnter(Collider obstacle)
    {
        string tag = obstacle.gameObject.tag;
        //Debug.Log("tag: " + tag);
        if( tag == "Player" )
        {
            obstacle.SendMessage(Game.Data.WasHitMsg);
			DestroySelfCollision();
        }
    }
}
