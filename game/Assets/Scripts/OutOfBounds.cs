using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	void OnTriggerEnter(Collider obstacle) {
		string tag = obstacle.gameObject.tag;
		//Debug.Log("tag: " + tag);
		obstacle.SendMessage(Game.Data.DestroySelfMsg, 
			SendMessageOptions.DontRequireReceiver);
	}
}
