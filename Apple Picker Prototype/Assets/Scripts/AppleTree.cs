using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour {
	
	public GameObject applePrefab;
	public float speed;

	public float basespeed = 10f;

	public float leftAndRightEdge = 20f;

	public float chanceToChangeDirections;

	public float basechanceToChangeDirections = 0.02f;

	public float secondsBetweenAppleDrops;

	public float basesecondsBetweenAppleDrops = 1f;

	public float currentLevel = 0;

	public Text scoreText;

	public int isGoingLeft = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("DropApple", 1f, secondsBetweenAppleDrops);
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		scoreText = scoreGO.GetComponent<Text>();
		//chanceToChangeDirections = basechanceToChangeDirections;
		secondsBetweenAppleDrops = basesecondsBetweenAppleDrops;
		speed = basespeed;
	}

	void DropApple()
	{
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
		Rigidbody appleRigidbody = apple.GetComponent<Rigidbody> ();
		appleRigidbody.velocity = new Vector3((Random.value * 10) - 5, (Random.value * 10) - 5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		int score = int.Parse (scoreText.text);
		float level = Mathf.Round(score / 1000);
		if (level > currentLevel) {
			currentLevel++;
			LevelUp ();
		}
		Vector3 position = transform.position;
		if (position.x >= leftAndRightEdge || position.x <= leftAndRightEdge * (-1)) {
			speed = (-1) * speed;
		}
		position.x += speed * Time.deltaTime;
		transform.position = position;
	}

	void FixedUpdate() {
		Vector3 position = transform.position;
		if (Random.value < chanceToChangeDirections && (position.x > -10 && position.x < 10) ) {
			speed = (-1) * speed;
		}
	}

	void LevelUp(){
		if (secondsBetweenAppleDrops > 0.25f) {
			CancelInvoke ();
			speed *= 1.1f;
			secondsBetweenAppleDrops /= 1.1f;
			InvokeRepeating ("DropApple", 1f, secondsBetweenAppleDrops);
		}
	}
}
