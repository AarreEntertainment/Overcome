using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {
	public GameObject title;
	public GameObject guru;
	public float endTimer = 3;
	public bool ended = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
		
		if (Input.GetButtonDown("Fire1")) {
			title.SetActive (false);
			guru.SetActive (true);
			ended = true;

		}
		if (endTimer > 0 && ended)
			endTimer -= Time.deltaTime;
		else if (ended && endTimer<= 0)
			SceneManager.LoadScene ("Main");
	}
}
