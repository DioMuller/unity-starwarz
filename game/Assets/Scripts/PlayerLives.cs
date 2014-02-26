using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour 
{
    public void WasHit()
    {
        Game.Data.DecreaseLives(1);
		Game.Data.CreateExplosion(transform.position);

		Destroy(gameObject);
    }
}
