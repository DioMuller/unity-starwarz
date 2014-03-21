using UnityEngine;

/// <summary>
/// Player mover component: Controls player movement and rotation.
/// </summary>
public class PlayerMover : MonoBehaviour 
{
	#region Public Attributes
	/// <summary>
	/// Movement speed.
	/// </summary>
	public float moveSpeed = 0.01f;

	/// <summary>
	/// The rotation speed.
	/// </summary>
	public float rotateSpeed = 2f;

	/// <summary>
	/// The maximum rotation angle (Euler).
	/// </summary>
	public float maxRotationAngle = 60f;
	#endregion Public Attributes

	#region Private Attributes
	/// <summary>
	/// The desired position.
	/// </summary>
	private Vector3 _desiredPosition;

	/// <summary>
	/// Player initial rotation.
	/// </summary>
	private Quaternion startRotation;

	/// <summary>
	/// Player minimum rotation.
	/// </summary>
	private Quaternion minRotation;

	/// <summary>
	/// Player max rotation.
	/// </summary>
	private Quaternion maxRotation;

	/// <summary>
	/// The bounds where player can move.
	/// </summary>
	private Bounds _bounds;
	#endregion Public Attributes

	#region MonoBehaviour Methods
	/// <summary>
	/// Initializes bounds and calculates rotations in Quaternions.
	/// </summary>
	void Start () 
	{
		CalculateBounds();
		startRotation = transform.rotation; //Quaternion.identity
		minRotation = startRotation * Quaternion.Euler(0, 0, maxRotationAngle);
		maxRotation = startRotation * Quaternion.Euler(0, 0, -maxRotationAngle);
	}

	/// <summary>
	/// Checks for inputs and move the player according to that.
	/// Rotates the player a bit to the desired direction, and considers bounds when
	/// calculating the new position.
	/// </summary>
	void Update () 
	{
		var dT = Time.deltaTime;
		var horInput = Input.GetAxis("Horizontal");
		var verInput = Input.GetAxis("Vertical");
		float hor = horInput * moveSpeed * dT;
		float ver = verInput * moveSpeed * dT;

		if (Mathf.Abs(horInput) > 0.1)
			ApplyRotation(horInput, dT);
		else 
		{
			RestoreRotation(dT);
		}

		_desiredPosition = transform.position + new Vector3(hor, 0, ver);

		if (!_bounds.Contains(_desiredPosition)) return;

		transform.position = _desiredPosition;

	}
	#endregion MonoBehaviour Methods

	#region Private Methods
	/// <summary>
	/// Calculates player movement bounds.
	/// </summary>
	private void CalculateBounds() 
	{
		var boundaryTR = Game.Data.boundaryTR;
		var boundaryBL = Game.Data.boundaryBL;
		
		_bounds = new Bounds(new Vector3((boundaryTR.position.x + boundaryBL.position.x)/2,
		                                 (boundaryTR.position.y + boundaryBL.position.y)/2,
		                                 (boundaryTR.position.z + boundaryBL.position.z)/2)
		                     ,
		                     new Vector3(boundaryTR.position.x - boundaryBL.position.x,
		            boundaryTR.position.y - boundaryBL.position.y,
		            -boundaryTR.position.z - boundaryBL.position.z));
	}

	/// <summary>
	/// Applies the rotation.
	/// </summary>
	/// <param name="horInput">Horizontal input.</param>
	/// <param name="dT">Delta time.</param>
	private void ApplyRotation(float horInput, float dT) 
	{
		if (horInput > 0.1f)
			transform.rotation = Quaternion.RotateTowards(
				transform.rotation, maxRotation, rotateSpeed*dT);
		else if (horInput < -0.1f)
			transform.rotation = Quaternion.RotateTowards(
				transform.rotation, minRotation, rotateSpeed*dT);
	}

	/// <summary>
	/// Restores the rotation to the original position.
	/// </summary>
	/// <param name="dT">Delta Time.</param>
	private void RestoreRotation(float dT) 
	{
		transform.rotation = Quaternion.RotateTowards(
			transform.rotation, Quaternion.identity, rotateSpeed * 4 * dT);		
	}
	#endregion Private Methods

}
