using UnityEngine;
using System.Collections;

public class FlamethrowerCollision : MonoBehaviour {

	private GameObject IceEthan;
	private GameObject FireWall;

	private ParticleSystem ice;
	private ParticleSystem wallFire;

	private float fireTimer;

	// Use this for initialization
	void Awake () {
		fireTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;

		if (ice) {
			if (ice.emissionRate >= 10) {
				Destroy (IceEthan);
			}

			if (fireTimer >= 10f) {
				ice.emissionRate -= 0.1f;
			}
			if (ice.emissionRate < 0f) {
				ice.emissionRate = 0f;
			}
		} else {

		}

		if (wallFire) {
			if (wallFire.emissionRate < 0f) {
				Destroy (FireWall);
			}
		}



	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();
		print (other.gameObject);
		if (body.tag == "IceEthan") {
			IceEthan = body.gameObject;
			ice = body.GetComponent<ParticleSystem> ();
			ice.emissionRate += 0.05f;
			fireTimer = 0.0f;
			print (ice.emissionRate);
		}else if (body.tag == "FireWall") {
			print ("0");
			FireWall = body.gameObject;
			print ("1");
			wallFire = body.GetComponent<ParticleSystem> ();
			print ("2");
			wallFire.emissionRate -= 1.0f;
			print ("3");

		}
	}
}
