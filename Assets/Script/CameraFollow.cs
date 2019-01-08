using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float smoothSpeed = 10f;
	public Vector3 offset;

	void FixedUpdate(){
		//Debug.Log ("working");
		Vector3 desiredPosition = target.position + offset;
		desiredPosition = new Vector3 (0, desiredPosition.y, desiredPosition.z);
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

	}
}
 