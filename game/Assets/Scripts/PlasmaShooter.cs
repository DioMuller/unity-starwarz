using System.Collections;
using UnityEngine;

public class PlasmaShooter : MonoBehaviour {

	public Transform PlasmaShot;
	public Transform PlasmaSpawnPosition;
	public float ReloadTime;
	private bool _canFire = true;

	void Update () {
		if (!_canFire) return;
		if (!Input.GetButton("Jump")) return;

		_canFire = false;
		StartCoroutine(ReloadTimer());
		Instantiate(PlasmaShot, PlasmaSpawnPosition.position, Quaternion.identity);
	}

	private IEnumerator ReloadTimer() {
		yield return new WaitForSeconds(ReloadTime);
		_canFire = true;
	}
}
