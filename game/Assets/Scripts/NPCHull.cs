using UnityEngine;

public class NPCHull : MonoBehaviour {

	public void WasHit() {
		Game.Data.IncreaseScore(1);
		Destroy(gameObject);
	}

	public void DestroySelf() {
		Destroy(gameObject);
	}
}
