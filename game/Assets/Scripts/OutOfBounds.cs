using UnityEngine;
using System.Collections;

/// <summary>
/// Out of bounds component: Sends destruction message to NPCs, if
/// those collide with the object.
/// </summary>
public class OutOfBounds : MonoBehaviour 
{
	/// <summary>
	/// If a collision occurs, send a destruction message to the
	/// other object.
	/// </summary>
	/// <param name="obstacle">Obstacle collider.</param>
	void OnTriggerEnter(Collider obstacle) 
	{
		//string tag = obstacle.gameObject.tag;
		//Debug.Log("tag: " + tag);
		obstacle.SendMessage(Game.Data.DestroySelfMsg, 
			SendMessageOptions.DontRequireReceiver);
	}
}
