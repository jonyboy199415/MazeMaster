using UnityEngine;
using System.Collections;

public class FlamethrowerCollision : MonoBehaviour {

	private GameObject IceEthan;

	private ParticleSystem ice;

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
		} else {

		}

	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();

		if (body.tag == "IceEthan") {
			IceEthan = body.gameObject;
			ice = body.GetComponent<ParticleSystem> ();
			ice.emissionRate += 0.1f;
			print (IceEthan + " " + ice.emissionRate);
		}
	}
}
