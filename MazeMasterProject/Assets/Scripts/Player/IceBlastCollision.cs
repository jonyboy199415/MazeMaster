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
			if (fire.emissionRate >= 10) {
				FireEthan.SetActive (false);
			}
		} else {

		}

	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();

		if (body.tag == "FireEthan") {
			FireEthan = body.GetComponent<GameObject> ();
			fire = body.GetComponent<ParticleSystem> ();
			fire.emissionRate -= 0.1f;
			print (fire.emissionRate);
		}
	}
}
