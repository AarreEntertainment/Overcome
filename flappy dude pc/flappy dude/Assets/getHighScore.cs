using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getHighScore : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		GetComponent<Text>().text = "Obstacles overcome: " + PlayerPrefs.GetFloat ("Score").ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
