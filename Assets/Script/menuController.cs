using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
	public Text record;
	void Start () {
		
		record.text = PlayerPrefs.GetInt ("record", 0).ToString ();
	}
	public void startTheGame(){
		SceneManager.LoadScene("001",LoadSceneMode.Single);
	}

	public void exit(){
		Application.Quit();
	} 
}
