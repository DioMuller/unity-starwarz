using UnityEngine;

public class PlasmaShot : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter (Collider obstacle) {
		string tag = obstacle.gameObject.tag;
		if (tag == "NPC") 
        {
			obstacle.SendMessage(Game.Data.WasHitMsg);
			DestroySelf();
		}
	}

	public void DestroySelf() {
		//Debug.Log("I was destroyed!");
		Destroy(gameObject);
	}
}
