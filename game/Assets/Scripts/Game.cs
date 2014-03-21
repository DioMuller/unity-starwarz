using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Game component: Game controller class, the "brain" of the game.
/// It keeps the score, player lives, controls NPC spawning and keeps 
/// a list of NPCs on screen ordered by
/// spawn/respawn order.
/// 
/// It also keeps the message names for specific methods to be called on
/// certain events, the map boundaries, limits NPC count, and updates the
/// GUI.
/// 
/// This class is also used to instantiate/call certain effects on the map,
/// using the same reference for all effects, independent of the place it's
/// called. This way, we only need to define wich prefab defines "Explosion" 
/// once, in the game, for example.
/// 
/// Everything in the game that must be used in different places is kept here.
/// </summary>
public class Game : MonoBehaviour 
{
	#region Static Attributes
	/// <summary>
	/// The singleton instance for this class.
	/// </summary>
	public static Game Data;
	#endregion Static Attributes

	#region Public Attributes
	/// <summary>
	/// Method name to be called on a "WasHit" message.
	/// </summary>
	public string WasHitMsg = "WasHit";

	/// <summary>
	/// Method name to be called on a "DestroySelf" message.
	/// </summary>
	public string DestroySelfMsg = "DestroySelf";

	/// <summary>
	/// Current game score.
	/// </summary>
	public int Score = 0;

	/// <summary>
	/// Player lives count.
	/// </summary>
	public int Lives = 3;

	#region Boundaries and Spawns
	/// <summary>
	/// The NPC spawn root.
	/// </summary>
	public Transform NPCSpawnRoot;

	/// <summary>
	/// Bottom Left Player Boundary.
	/// </summary>
	public Transform boundaryBL;

	/// <summary>
	/// Top Right Player Boundary.
	/// </summary>
	public Transform boundaryTR;
	#endregion Boundaries and Spawns

	#region Transforms and Effects
	/// <summary>
	/// The player ship.
	/// </summary>
	public Transform playerShip;

	/// <summary>
	/// The explosion effect.
	/// </summary>
	public Transform explosionEffect;
    
	/// <summary>
	/// The teleport effect.
	/// </summary>
	public Transform teleportEffect;
	#endregion Transforms and Effects
	
	#region NPC Data
	/// <summary>
	/// The NPC Game Object.
	/// </summary>
	public GameObject NPC;

	/// <summary>
	/// The NPC count limit.
	/// </summary>
	public int NPCLimit = 20;

	/// <summary>
	/// The current NPC count.
	/// </summary>
	public int NPCCount = 0;
	#endregion NPC Data

	#region GUI
	/// <summary>
	/// The GUI score Text Mesh.
	/// </summary>
	public TextMesh GUIScore;

	/// <summary>
	/// The GUI lives Text Mesh.
	/// </summary>
	public TextMesh GUILives;

	/// <summary>
	/// The GUI game over Text Mesh.
	/// </summary>
	public TextMesh GUIGameOver;

	/// <summary>
	/// The GUI game over message Text Mesh.
	/// </summary>
	public TextMesh GUIGameOverMessage;
	#endregion GUI

	/// <summary>
	/// The latest spawned NPCs, most recent comes first.
	/// </summary>
	public List<Transform> LatestNPCs;

	/// <summary>
	/// Player respawn time after being destroyed.
	/// </summary>
	public float RespawnTime = 3f;

	#endregion Public Attributes

	#region MonoBehavior Methods
	/// <summary>
	/// Called on start. Invokes the NPC spawn method repeating each 1 second.
	/// </summary>
	public void Start() 
	{
		InvokeRepeating("NPCSpawn", 0f, 1f);

		LatestNPCs = new List<Transform> ();
	}

	/// <summary>
	/// Called on waking. Sets the singleton as this instance.
	/// </summary>
	void Awake () 
	{
		Data = this;
	}

	/// <summary>
	/// Checks for ESC input. If game is over and ESC pressed, returns to title screen.
	/// </summary>
	void Update()
	{
		if( !Input.GetKeyDown(KeyCode.Escape) ) return;

		// Only in case of Game Over.
		if( Lives <= 0 ) Application.LoadLevel("starwarz-title");
	}
	#endregion MonoBehavior Methods

	#region Score and Life Methods
	/// <summary>
	/// Increases the score by chosen bonus.
	/// </summary>
	/// <param name="scoreBonus">Score bonus.</param>
	public void IncreaseScore(int scoreBonus) 
	{
		Score += scoreBonus;
		GUIScore.text = "Score: " + Score;
	}

	/// <summary>
	/// Decreases the lives by chosen quantity.
	/// </summary>
	/// <param name="lives">Lives to decrease.</param>
	public void DecreaseLives(int lives)
	{
		Lives -= lives;
		GUILives.text = "Lives: " + Lives;

		RespawnShip();
	}
	#endregion Scores and Life Methods

	#region Spawning Methods
	/// <summary>
	/// Respawns the ship, if the player has lives remaining.
	/// Shows game over screen if he doesn't.
	/// </summary>
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

	/// <summary>
	/// Spawns the player after defined time.
	/// </summary>
	/// <returns>The waiting time.</returns>
	private IEnumerator SpawnAfterTime() 
	{
		yield return new WaitForSeconds(RespawnTime);
		Instantiate(playerShip);
	}

	/// <summary>
	/// Spawns NPC.
	/// </summary>
	public void NPCSpawn() 
	{
		// Checks if the number of NPCs surpasses the limit
		if( NPCCount >= NPCLimit ) return;
		
		float xpos = Random.Range(boundaryBL.position.x, boundaryTR.position.x);
		Vector3 newSpawnPos = new Vector3(xpos, NPCSpawnRoot.position.y, NPCSpawnRoot.position.z);
		ShowTeleportEffect(newSpawnPos);
		var trans = Instantiate(NPC, newSpawnPos, Quaternion.identity) as GameObject;
		LatestNPCs.Insert (0, trans.transform);
		NPCCount++;
	}
	#endregion Spawning Methods

	#region Effects Methods
	/// <summary>
	/// Creates a explosion at the given position.
	/// </summary>
	/// <param name="position">Position.</param>
	public void CreateExplosion(Vector3 position)
	{
		Instantiate(explosionEffect, position, Quaternion.identity);
	}

	/// <summary>
	/// Shows the teleport effect at position.
	/// </summary>
	/// <param name="position">Position.</param>
	public void ShowTeleportEffect(Vector3 position)
	{
		Instantiate(teleportEffect, position, Quaternion.identity);
	}
	#endregion Effects Methods
}
