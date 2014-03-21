using UnityEngine;
using System.Collections;

/// <summary>
/// Title component: Checks if the Jump button is pressed.
/// If it is, loads game.
/// </summary>
public class Title : MonoBehaviour 
{
	/// <summary>
	/// Checks if the Jump button is pressed.
	/// If it is, loads game.
	/// </summary>
	void Update () 
	{
		if (!Input.GetButton("Jump")) return;

		Application.LoadLevel("starwarz-game");
	}
}
