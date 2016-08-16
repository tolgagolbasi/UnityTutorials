using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainMenuHighScore : MonoBehaviour {

	public Text mainMenuText;

	public int highestScore = 0;

	public string highestScorePlayerName = "Unknown";
	// Use this for initialization
	void Start () {
		mainMenuText = this.GetComponent<Text> ();

		if(PlayerPrefs.HasKey(HighScore.highScoreKey)){
			highestScore = PlayerPrefs.GetInt(HighScore.highScoreKey);
		}
		if(PlayerPrefs.HasKey(HighScore.highScorePlayerKey)){
			highestScorePlayerName = PlayerPrefs.GetString(HighScore.highScorePlayerKey);
		}

		mainMenuText.text = "Highest Score: " + highestScore + " by Player " + highestScorePlayerName;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
