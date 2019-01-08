using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class uiController : MonoBehaviour {

	public GameObject pausePanel;
	public GameObject ball;
	public bool ispause = false;
	Player playerInstanc;
	public GameObject adPanel;
	public Text lifeBord;

	void Start(){
		playerInstanc = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

	}
	public void pause(){
		if (!ispause) {
			ispause = true;
			pausePanel.SetActive (true);
			Time.timeScale = 0f;
		}
	}
	public void goToMenu(){
		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;
		}
		SceneManager.LoadScene("menu",LoadSceneMode.Single);
	}

	public void startTheGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("001",LoadSceneMode.Single);
	}


	public void resume(){
		if (ispause) {
			ispause = false;
			pausePanel.SetActive (false);
			Time.timeScale = 1f;
		}
	}

	public void exit(){
		Time.timeScale = 1f;
		Application.Quit ();
	}

	public void ad(){
		Time.timeScale = 1f;
		playerInstanc.isSafeMood = true;
		adPanel.SetActive (false);
		playerInstanc.health++;
		lifeBord.text = playerInstanc.health.ToString();
		StartCoroutine (blanking ());
	}

	IEnumerator blanking () {
		bool b = false;
		for (int i = 0; i < 30; i++) {
			yield return new WaitForSeconds (0.1f);
			playerInstanc.sprite.enabled = b;
			b = !b;
		}
		playerInstanc.sprite.enabled = true;
		playerInstanc.isSafeMood = false;
	}
}