using UnityEngine;
using System.Collections;

public class IceBlastCollision : MonoBehaviour {
	private GameObject FireEthan;
	private GameObject FireWall;

	private ParticleSystem fire;
	private ParticleSystem wallFire;

	private float fireTimer;

	// Use this for initialization
	void Start () {
		fireTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;
		if (fire) {
			if (fire.emissionRate < 0f) {
				Destroy (FireEthan);
			}

			if (fireTimer >= 10f) {
				fire.emissionRate += 0.1f;
			}

			if (fire.emissionRate > 10f) {
				fire.emissionRate = 10f;
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
		if (body.tag == "FireEthan") {
			FireEthan = body.gameObject;
			fire = body.GetComponent<ParticleSystem> ();
			fire.emissionRate -= 1f;
			fireTimer = 0.0f;
			print (fire.emissionRate);
		}

		if (body.tag == "FireWall") {
			print ("0");
			FireWall = body.gameObject;
			print ("1");
			wallFire = body.GetComponent<ParticleSystem> ();
			print ("2");
			wallFire.emissionRate = 0.0f;
			print ("3");

		}
	}
}
