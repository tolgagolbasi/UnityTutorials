using UnityEngine;
using System.Collections;

public class sc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 temp = transform.position;
		float a = Screen.width / 2;
		float b = Screen.height / 2;
		temp.x = ((Input.mousePosition.x - a)/a)-5;
		temp.y = ((Input.mousePosition.y - b)/b)+5;
		transform.position = temp;
		Debug.Log(Input.mousePosition.x);
	}
}
