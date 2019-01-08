using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Player : MonoBehaviour {

	public Text scoreBord;
	public Text lifeBord;
	Rigidbody2D rb;
	public Vector2 dir;
	public float force=1;
	public Vector2 worldPoint2d;
	private int score = 0;
	public AudioSource sound;
	public int health = 3;
	public Touch touch;
	public SpriteRenderer sprite;
	public bool isSafeMood;
	public GameObject adPanel;
	public GameObject gameOverPanel;
	bool isGameWillOver = false;

	void Start () {
		sound = GetComponent<AudioSource> ();
		rb = GetComponent<Rigidbody2D>();
		scoreBord.text = "0";
		lifeBord.text = health.ToString();
		sprite = GetComponent<SpriteRenderer> ();
	}

	void Update () {
		if (score < Mathf.Abs((int)transform.position.y)) {
			score = Mathf.Abs((int)transform.position.y);
			scoreBord.text=score.ToString();
		}

		if (score > PlayerPrefs.GetInt ("record", 0)) {
			PlayerPrefs.SetInt("record",score);
		}
	}

	void FixedUpdate (){
		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);
			Vector3 worldPoint = Camera.main.ScreenToWorldPoint (touch.position);
			worldPoint2d = new Vector2 (worldPoint.x, worldPoint.y);

			dir = new Vector2 (transform.position.x, transform.position.y) - worldPoint2d;

			int id = touch.fingerId;
			if (!EventSystem.current.IsPointerOverGameObject (id)) {
				
				rb.AddForceAtPosition (dir.normalized * force, new Vector2 (transform.position.x, transform.position.y));
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("ndl")) {
			if (!isSafeMood) {
				if (health > 1) {
					explode ();
				} else if (!isGameWillOver) {
					ad ();
					isGameWillOver = true;
				} else {
					GameOver ();
				}
			}
		}
	}

	void explode(){
		isSafeMood = true;
		sound.Play ();
		health -= 1;
		lifeBord.text = health.ToString();
		StartCoroutine (blanking ());
	}

	IEnumerator blanking () {
		bool b = false;
		for (int i = 0; i < 30; i++) {
			yield return new WaitForSeconds (0.1f);
			sprite.enabled = b;
			b = !b;
		}
		sprite.enabled = true;
		isSafeMood = false;
	}

	void ad(){
		sound.Play ();
		adPanel.SetActive (true);
		health -= 1;
		lifeBord.text = health.ToString();
		Time.timeScale = 0f;
	}

	void GameOver(){
		sound.Play ();
		gameOverPanel.SetActive (true);
		health -= 1;
		lifeBord.text = health.ToString();
		Time.timeScale = 0f;
	}
}