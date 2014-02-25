using UnityEngine;

public class NPCHull : MonoBehaviour {

	public void WasHit() 
	{
		Game.Data.IncreaseScore(1);
		Game.Data.LatestNPCs.Remove (transform);
		Destroy(gameObject);
	}

	public void DestroySelf() 
	{
		Game.Data.LatestNPCs.Remove (transform);
		Destroy(gameObject);
	}

    public void OnTriggerEnter(Collider obstacle)
    {
        string tag = obstacle.gameObject.tag;
        Debug.Log("tag: " + tag);
        if( tag == "Player" )
        {
            obstacle.SendMessage(Game.Data.WasHitMsg);
            DestroySelf();
        }
    }
}
