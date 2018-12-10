using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	Rigidbody2D rb;
	public Vector2 dir;
	public float makan=0;
	public float force=1;
	public Vector2 worldPoint2d;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate (){
		
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		worldPoint2d = new Vector2 (worldPoint.x, worldPoint.y);

		dir = new Vector2 (transform.position.x, transform.position.y) - worldPoint2d;
		if (Input.GetMouseButton (0)) {
			rb.AddForceAtPosition (dir.normalized * force, new Vector2 (transform.position.x, transform.position.y));
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("ndl")) {
			Destroy (gameObject);
		}
	}
}