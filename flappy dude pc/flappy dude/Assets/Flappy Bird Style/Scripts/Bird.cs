using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody rb;				//Holds a reference to the Rigidbody2D component of the bird.
	public AudioSource music;
	public AudioSource deathswoop;

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//Don't allow control if the bird has died.
		if (isDead == false) 
		{
			//Look for input to trigger a "flap".
			if (Input.GetButtonDown("Fire1") && transform.position.y<3f) 
			{
				GetComponent<AudioSource> ().Play ();
				//...tell the animator about it and then...
				anim.SetTrigger("Flap");
				//...zero out the birds current y velocity before...
				rb.velocity = Vector3.zero;
				//	new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb.AddForce(new Vector3(0, upForce, 0));
			}
		}
	}

	void OnCollisionEnter(Collision other)
	{
		die (other);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name.Contains("corinthian")||other.name.Contains("ground"))
			die(null);
	}

	void die(Collision other)
	{
		music.pitch = 0.7f;
		deathswoop.Play ();
		// Zero out the bird's velocity
		rb.velocity = Vector3.zero;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		if (other != null) {
			other.rigidbody.velocity = Vector3.zero;
			other.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		}
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
	}

}
