using UnityEngine;
using System.Collections;

/// <summary>
/// Mover component: Makes a object move in a defined direction.
/// </summary>
public class Mover : MonoBehaviour 
{
	/// <summary>
	/// Movement offset.
	/// </summary>
	public Vector3 Offset;
	/// <summary>
	/// Does the object use a random movement offset?
	/// </summary>
    public bool useRandomOffset = false;
	/// <summary>
	/// The minimum percentage for the random offset.
	/// </summary>
    public float percentageMinDifference = 0.5f;
	/// <summary>
	/// The maximum percentage for the random offset.
	/// </summary>
    public float percentageMaxDifference = 2f;

 	/// <summary>
 	/// If the object uses random offsets, randomize the offset.
 	/// </summary>
 	void Start () 
    {
 	    if( useRandomOffset )
        {
            Offset *= Random.Range(percentageMinDifference, percentageMaxDifference);
        }
 	}

	/// <summary>
	/// Translate the object in the desired direction.
	/// </summary>
	void Update () 
    {
		var dT = Time.deltaTime;
		transform.Translate(Offset * dT);
	}
}
