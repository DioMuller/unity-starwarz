using UnityEngine;
using System.Collections;

/// <summary>
/// Destroyer component: Destroys the game object after a defined time.
/// </summary>
public class Destroyer : MonoBehaviour 
{
	/// <summary>
	/// The wait time before destroying the object.
	/// </summary>
	public float WaitTime = 3.0f;

	/// <summary>
	/// Starts the Destroy Object coroutine on waking.
	/// </summary>
	void Awake () 
	{
		StartCoroutine(DestroyAfterDelay());	
	}

	/// <summary>
	/// Destroys the object after delay.
	/// </summary>
	/// <returns>The object after delay.</returns>
	private IEnumerator DestroyAfterDelay() 
	{
		yield return new WaitForSeconds(WaitTime);
		Destroy(gameObject);
	}
}
