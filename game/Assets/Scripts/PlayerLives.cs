using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour 
{
    public void WasHit()
    {
        Game.Data.DecreaseLives(1);
        // TODO: Explode!
    }
}
