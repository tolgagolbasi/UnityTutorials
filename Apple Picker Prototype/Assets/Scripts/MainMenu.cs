using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	
	static public string currentPlayerName = "Unknown";
	static public string currentPlayerKey = "ApplePickerCurrentPlayer";
	public Text currentPlayerInput;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartGame() {
		PlayerPrefs.SetString (currentPlayerKey, currentPlayerName);
		Application.LoadLevel ("_Scene_0");
	}

	public void EndGame() {
		Application.Quit ();
	}

	public void setPlayerName(string value){
		currentPlayerName = value;
	}
}
