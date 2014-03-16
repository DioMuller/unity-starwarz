using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if (!Input.GetButton("Jump")) return;

		Application.LoadLevel("starwarz-game");
	}
}
