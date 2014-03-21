using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour 
{
	public Transform EnemyShot;
	public Transform EnemySpawnPosition;
	public float ReloadTime = 3.0f;
	
	void Awake() 
	{
		// First shot will be fired in a random time between 0 and Reload Time.
		float start = Random.Range(0.0f, ReloadTime);

		InvokeRepeating("Shoot", start, ReloadTime);
	}
	
	private void Shoot() 
	{
        Instantiate(EnemyShot, EnemySpawnPosition.position, Quaternion.identity);
	}
}
