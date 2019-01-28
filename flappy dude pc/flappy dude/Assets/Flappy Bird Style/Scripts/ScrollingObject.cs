using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb = GetComponent<Rigidbody>();

		//Start the object moving.
		rb.velocity = new Vector3 (GameControl.instance.scrollSpeed, 0,0);

	}

	void Update()
	{
		// If the game is over, stop scrolling.
		if(GameControl.instance.dead == true)
		{
			rb.velocity = Vector3.zero;
		}
	}
}
