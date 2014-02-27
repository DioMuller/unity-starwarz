using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour 
{
	public float WaitTime = 3.0f;

	// Use this for initialization
	void Awake () 
	{
		StartCoroutine(DestroyAfterDelay());	
	}
	
	private IEnumerator DestroyAfterDelay() 
	{
		yield return new WaitForSeconds(WaitTime);
		Destroy(gameObject);
	}
}
