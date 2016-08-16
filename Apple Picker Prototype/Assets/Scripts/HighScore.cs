using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	static public string highScoreKey = "ApplePickerHighScore";
	static public string highScorePlayerKey = "ApplePickerHighScorePlayer";
	static public string isPlayerHasHighestScoreKey = "ApplePickerIsHighScorePlayer";
	static public int score = 0;
	public string highScorePlayerName = "Unknown";
	public string currentPlayerName = "Unknown";


	void Awake(){
		if(PlayerPrefs.HasKey(highScoreKey)){
			score = PlayerPrefs.GetInt(highScoreKey);
		}
		if(PlayerPrefs.HasKey(highScorePlayerKey)){
			highScorePlayerName = PlayerPrefs.GetString(highScorePlayerKey);
		}
		if(PlayerPrefs.HasKey(MainMenu.currentPlayerKey)){
			currentPlayerName = PlayerPrefs.GetString(MainMenu.currentPlayerKey);
		}
		PlayerPrefs.SetInt (highScoreKey, score);

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Text highScoreText = this.GetComponent<Text>();
		highScoreText.text = highScorePlayerName + ": " + score;
		if (score > PlayerPrefs.GetInt (highScoreKey)) {
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.SetString (highScorePlayerKey, currentPlayerName);
			PlayerPrefs.SetInt (isPlayerHasHighestScoreKey, 1);
		}

	}
}
