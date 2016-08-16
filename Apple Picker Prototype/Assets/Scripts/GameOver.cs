using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Text gameOverText;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		gameOverText = this.GetComponent<Text>();
		if (PlayerPrefs.HasKey (HighScore.isPlayerHasHighestScoreKey)) {
			string highestScorePlayerName = "Unknown";
			int highestScore = 0;
			if (PlayerPrefs.GetInt (HighScore.isPlayerHasHighestScoreKey) == 1) {
				if (PlayerPrefs.HasKey (HighScore.highScoreKey)) {
					highestScore = PlayerPrefs.GetInt (HighScore.highScoreKey);
				}
				if (PlayerPrefs.HasKey (HighScore.highScorePlayerKey)) {
					highestScorePlayerName = PlayerPrefs.GetString (HighScore.highScorePlayerKey);
				}
				gameOverText.text = "Nice Job! " + highestScorePlayerName + ", You got the highest score of " + highestScore + "!";
			} else {
				gameOverText.text = "Game Over! Better Luck Next Time :)";
			}
		}
	}
	public void Replay() {
		PlayerPrefs.SetInt (HighScore.isPlayerHasHighestScoreKey, 0);
		Application.LoadLevel ("_Scene_0");
	}
	public void EndGame() {
		Application.Quit ();
	}
}
