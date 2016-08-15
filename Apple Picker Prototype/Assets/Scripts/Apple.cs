using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	
	public static float bottomY = -20;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= -20) {
			Destroy (this.gameObject);
		}
	}
}
