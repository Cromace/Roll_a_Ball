using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	private Light myLight;
	static int count = Player_Controller.count;
	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light> ();
		myLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		count = Player_Controller.count;
		if (count >= 9) {
			myLight.enabled = true;
		}
	}
}
