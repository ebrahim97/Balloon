using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	player playerInstanc;
	GameObject playerGameObject;
	public AudioSource sound;
	public float decSpeed=0.2f;
	bool makeSoundZero;
	// Use this for initialization
	void Start () {
		playerGameObject = GameObject.FindGameObjectWithTag ("Player");
		playerInstanc =	playerGameObject.GetComponent<player> ();
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float rot_z = Mathf.Atan2(playerInstanc.dir.y, playerInstanc.dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		transform.position = playerInstanc.worldPoint2d;

		if (Input.GetMouseButtonDown(0)) {
			sound.Play ();
			sound.volume = 1f;
			makeSoundZero = false;
		}

		if(Input.GetMouseButtonUp(0)){
			makeSoundZero = true;
		}

		if (makeSoundZero) {
			sound.volume -= decSpeed * Time.deltaTime;

			if (sound.volume <= 0) {
				makeSoundZero = false;
				sound.Stop ();
			}
		}

	}
		
}
