using UnityEngine;
using System.Collections;

public class IceBlastCollision : MonoBehaviour {
	private GameObject FireEthan;

	private ParticleSystem fire;

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



	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();

		if (body.tag == "FireEthan") {
			FireEthan = body.gameObject;
			fire = body.GetComponent<ParticleSystem> ();
			fire.emissionRate -= 1f;
			fireTimer = 0.0f;
			print (fire.emissionRate);
		}
	}
}
