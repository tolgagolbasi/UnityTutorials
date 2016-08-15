using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {
	
	public GameObject applePrefab;
		
	public float speed = 10f;

	public float leftAndRightEdge = 20f;

	public float chanceToChangeDirections = 0.02f;

	public float secondsBetweenAppleDrops = 1f;
		
	// Use this for initialization
	void Start () {
		InvokeRepeating ("DropApple", 2f, secondsBetweenAppleDrops);
	
	}

	void DropApple()
	{
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		if (position.x >= leftAndRightEdge || position.x <= leftAndRightEdge * (-1)) {
			speed = (-1) * speed;
		}
		position.x += speed * Time.deltaTime;
		transform.position = position;
	}

	void FixedUpdate() {
		if (Random.value < chanceToChangeDirections) {
			speed = (-1) * speed;
		}
	}
}
