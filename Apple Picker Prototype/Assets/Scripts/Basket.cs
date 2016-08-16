using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	public Text scoreText;
	void Start(){
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreText = scoreGO.GetComponent<Text>();
	}

	void Update () {
		// Get the current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition;
		// 1
		// The Camera's z position sets the how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z;
		// 2
		// Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
		// 3// Move the x position of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter( Collision coll ) {
		// Find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if ( collidedWith.tag == "Apple" ) {
			Destroy( collidedWith );
		}

		int score = int.Parse (scoreText.text);
		score += 100;
		scoreText.text = score.ToString ();

		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
