using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textRandomizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string[] wisdoms = (Resources.Load ("wisdoms") as TextAsset).text.Split('\n');
		GetComponent<Text>().text =  (wisdoms[Random.Range(0, wisdoms.Length)]) + "\n---Guru Sibul Gurk-Porgan";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}