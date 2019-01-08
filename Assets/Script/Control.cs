using UnityEngine;
using UnityEngine.EventSystems;

public class Control : MonoBehaviour {

	Player playerInstanc;
	AudioSource sound;
	public float decSpeed=0.2f;
	bool makeSoundZero;

	// Use this for initialization
	void Start () {

		playerInstanc = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		sound = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		float rot_z = Mathf.Atan2(playerInstanc.dir.y, playerInstanc.dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		transform.position = playerInstanc.worldPoint2d;

		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject (playerInstanc.touch.fingerId)) {
				sound.Play ();
				sound.volume = 1f;
				makeSoundZero = false;
			}
	
			if (Input.GetTouch (0).phase == TouchPhase.Ended) {
				makeSoundZero = true;

			}
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