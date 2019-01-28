using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<Bird>() != null)
		{

			GetComponent<AudioSource> ().Play ();
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			GameControl.instance.BirdScored();
		}
	}
}
