using UnityEngine;
using System.Collections;

public class FlameOn : MonoBehaviour {

	public ParticleSystem flames;
	private bool flameOn;

	// Use this for initialization
	void Awake () {
		flames.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E)) {
			flames.Play ();
			flameOn = true;
			flames.emissionRate = 100f;
		} else {
			flameOn = false;
			flames.emissionRate = 0.0f;
		}
	}

	void OnParticleCollision(GameObject other){
		//Rigidbody body = other.GetComponent<Rigidbody> ();
		print ("Hit");
		/*if (other.tag == "Enemy") {
			print ("Enemy");
		}
		if (body.tag == "Enemy") {
			Vector3 direction = other.transform.position - transform.position;
			print (body.tag);
			direction = direction.normalized;
			body.AddForce (direction * 5);
		}*/
	}


}
