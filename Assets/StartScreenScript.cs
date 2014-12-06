using UnityEngine;
using System.Collections;

public class StartScreenScript : MonoBehaviour {

	static bool sawOnce = false;

	// Use this for initialization --  http://bit.ly/unity3diy
	void Start () {
		if(!sawOnce) {
			GetComponent<SpriteRenderer>().enabled = true;
			Time.timeScale = 0;
		}

		sawOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale==0 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) ) {
			Time.timeScale = 1;
			GetComponent<SpriteRenderer>().enabled = false;

		}
	}
}
