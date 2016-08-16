using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public List<GameObject> basketList;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;

	void Start () {
		basketList = new List<GameObject> ();
		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}
	public void AppleDestroyed(){
		GameObject[] appleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject apple in appleArray) {
			Destroy (apple);
		}

		int basketIndex = basketList.Count - 1;
		GameObject basketToRemove = basketList [basketIndex];
		basketList.RemoveAt (basketIndex);
		Destroy (basketToRemove);

		if (basketList.Count == 0) {
			Application.LoadLevel ("_Scene_0");
		}
	}
}
