using UnityEngine;

public class Shot : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// The target tag. Only targets with this tag will be hit.
	/// </summary>
	public string TargetTag = "NPC";
	#endregion Public Attributes

	#region MonoBehaviour Methods
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
	#endregion MonoBehaviour Methods

	#region Message Implementations
	/// <summary>
	/// Implementation of the DestroySelf message.
	/// Destroys this object.
	/// </summary>
	public void DestroySelf() 
	{
		//Debug.Log("I was destroyed!");
		Destroy(gameObject);
	}
	#endregion Message Implementations
}
