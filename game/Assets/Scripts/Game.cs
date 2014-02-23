using UnityEngine;

public class Game : MonoBehaviour {

	public static Game Data;
	public string WasHitMsg = "WasHit";
	public string DestroySelfMsg = "DestroySelf";
	public int Score = 0;
	public Transform NPCSpawnRoot;
	public Transform boundaryBL;
	public Transform boundaryTR;
	public GameObject NPC;
	public TextMesh GUIScore;
	public TextMesh GUILives;
	public Transform latestNPC;

	public void Start() {
		InvokeRepeating("NPCSpawn", 1f, 4f);
	}

	void Awake () {
		Data = this;
	}

	public void IncreaseScore(int scoreBonus) {
		Score += scoreBonus;
		GUIScore.text = "Score: " + Score;
	}

	public void NPCSpawn() 
	{
		float xpos = Random.Range(boundaryBL.position.x, boundaryTR.position.x);
		Vector3 newSpawnPos = new Vector3(xpos, NPCSpawnRoot.position.y, NPCSpawnRoot.position.z);
		var trans = Instantiate(NPC, newSpawnPos, Quaternion.identity) as GameObject;
		latestNPC = trans.transform;
	}

}
