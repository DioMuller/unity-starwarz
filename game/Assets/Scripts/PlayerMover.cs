using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float moveSpeed = 0.01f;
	public Transform boundaryBL;
	public Transform boundaryTR;
	private Bounds _bounds;
	private Vector3 _desiredPosition;
	public float rotateSpeed = 2f;
	public float maxRotationAngle = 60f;
	private Quaternion startRotation, minRotation, maxRotation;

	void Start () {
		CalculateBounds();
		startRotation = transform.rotation; //Quaternion.identity
		minRotation = startRotation * Quaternion.Euler(0, 0, maxRotationAngle);
		maxRotation = startRotation * Quaternion.Euler(0, 0, -maxRotationAngle);
	}

	private void CalculateBounds() {
		_bounds = new Bounds(new Vector3((boundaryTR.position.x + boundaryBL.position.x)/2,
										 (boundaryTR.position.y + boundaryBL.position.y)/2,
										 (boundaryTR.position.z + boundaryBL.position.z)/2)
							 ,
							 new Vector3(boundaryTR.position.x - boundaryBL.position.x,
										 boundaryTR.position.y - boundaryBL.position.y,
										 -boundaryTR.position.z - boundaryBL.position.z));
	}

	void Update () {
		var dT = Time.deltaTime;
		var horInput = Input.GetAxis("Horizontal");
		var verInput = Input.GetAxis("Vertical");
		float hor = horInput * moveSpeed * dT;
		float ver = verInput * moveSpeed * dT;

		if (Mathf.Abs(horInput) > 0.1)
			ApplyRotation(horInput, dT);
		else {
			RestoreRotation(dT);
		}

		_desiredPosition = transform.position + new Vector3(hor, 0, ver);

		if (!_bounds.Contains(_desiredPosition)) return;

		transform.position = _desiredPosition;

	}

	private void ApplyRotation(float horInput, float dT) {
		if (horInput > 0.1f)
			transform.rotation = Quaternion.RotateTowards(
				transform.rotation, maxRotation, rotateSpeed*dT);
		else if (horInput < -0.1f)
			transform.rotation = Quaternion.RotateTowards(
				transform.rotation, minRotation, rotateSpeed*dT);
	}

	private void RestoreRotation(float dT) {
		transform.rotation = Quaternion.RotateTowards(
			transform.rotation, Quaternion.identity, rotateSpeed * 4 * dT);		
	}

}
