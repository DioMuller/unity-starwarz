using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public Vector3 Offset;
    public bool useRandomOffset = false;
    public float percentageMinDifference = 0.5f;
    public float percentageMaxDifference = 2f;

 	// Use this for initialization
 	void Start () 
    {
 	    if( useRandomOffset )
        {
            Offset *= Random.RandomRange(percentageMinDifference, percentageMaxDifference);
        }
 	}
	
	void Update () 
    {
		var dT = Time.deltaTime;
		transform.Translate(Offset * dT);
	}
}
