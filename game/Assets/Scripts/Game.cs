using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public static Game Data;
	public string WasHitMsg = "WasHit";
	public string DestroySelfMsg = "DestroySelf";
	public int Score = 0;
	public int Lives = 3;
	public Transform NPCSpawnRoot;
	public Transform boundaryBL;
	public Transform boundaryTR;
	public Transform playerShip;
	public Transform explosionEffect;
	public GameObject NPC;

	#region GUI
	public TextMesh GUIScore;
	public TextMesh GUILives;
	public TextMesh GUIGameOver;
	public TextMesh GUIGameOverMessage;
	#endregion GUI

	public List<Transform> LatestNPCs;
	public float RespawnTime = 3f;

	public void Start() 
	{
		InvokeRepeating("NPCSpawn", 1f, 4f);

		LatestNPCs = new List<Transform> ();
	}

	void Awake () 
	{
		Data = this;
	}

	void Update()
	{
		if( !Input.GetKeyDown(KeyCode.Escape) ) return;

		// Only in case of Game Over.
		if( Lives <= 0 ) Application.LoadLevel("starwarz-title");
	}

	public void IncreaseScore(int scoreBonus) 
	{
		Score += scoreBonus;
		GUIScore.text = "Score: " + Score;
	}

	public void DecreaseLives(int lives)
	{
		Lives -= lives;
		GUILives.text = "Lives: " + Lives;

		RespawnShip ();
	}

	public void RespawnShip()
	{
		if (Lives > 0) 
		{
			StartCoroutine (SpawnAfterTime());
		} 
		else 
		{
			GUIGameOver.renderer.enabled = true;
			GUIGameOverMessage.renderer.enabled = true;
		}
	}

	private IEnumerator SpawnAfterTime() 
	{
		yield return new WaitForSeconds(RespawnTime);
		Instantiate(playerShip);
	}

	public void CreateExplosion(Vector3 position)
	{
		Instantiate(explosionEffect, position, Quaternion.identity);
	}

	public void NPCSpawn() 
	{
		float xpos = Random.Range(boundaryBL.position.x, boundaryTR.position.x);
		Vector3 newSpawnPos = new Vector3(xpos, NPCSpawnRoot.position.y, NPCSpawnRoot.position.z);
		var trans = Instantiate(NPC, newSpawnPos, Quaternion.identity) as GameObject;
		LatestNPCs.Insert (0, trans.transform);
	}
}
