using UnityEngine;
using System.Collections;

public class MissileShoter : MonoBehaviour {

	public Transform MissileShot;
	public Transform MissileSpawnPosition;
	public float ReloadTime;
	private bool _canFire = true;
	
	void Update () {
		if (!_canFire) return;
		if (!Input.GetButton("Fire1")) return;
		
		_canFire = false;
		StartCoroutine(ReloadTimer());
		Instantiate(MissileShot, MissileSpawnPosition.position, Quaternion.identity);
	}
	
	private IEnumerator ReloadTimer() {
		yield return new WaitForSeconds(ReloadTime);
		_canFire = true;
	}
}
