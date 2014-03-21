using UnityEngine;

public class Shot : MonoBehaviour 
{
	/// <summary>
	/// The target tag. Only targets with this tag will be hit.
	/// </summary>
	public string TargetTag = "NPC";

	/// <summary>
	/// Collision Event. If the other object tag is TargetTag,
	/// send a WasHit message to it.
	/// </summary>
	/// <param name="obstacle">Obstacle collider.</param>
	void OnTriggerEnter (Collider obstacle) 
	{
		string tag = obstacle.gameObject.tag;

		if ( tag != TargetTag ) return;

		obstacle.SendMessage(Game.Data.WasHitMsg);
		DestroySelf();
	}

	/// <summary>
	/// Implementation of the DestroySelf message.
	/// Destroys this object.
	/// </summary>
	public void DestroySelf() 
	{
		//Debug.Log("I was destroyed!");
		Destroy(gameObject);
	}
}
