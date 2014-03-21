using UnityEngine;

public class PlasmaShot : MonoBehaviour {
	public string TargetTag = "NPC";
	// Update is called once per frame
	void OnTriggerEnter (Collider obstacle) {
		string tag = obstacle.gameObject.tag;
		if ( tag == TargetTag ) 
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
