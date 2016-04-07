using UnityEngine;
using System.Collections;

public class FlamethrowerCollision : MonoBehaviour {

	public ParticleSystem enemyFire;
	public GameObject IceEthan;

	public float fireTimer;

	// Use this for initialization
	void Start () {
		fireTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer += Time.deltaTime;

		if (enemyFire.emissionRate >= 3f) {
			IceEthan.SetActive (false);
		}

		if (fireTimer >= 10) {
			enemyFire.emissionRate -= 0.05f;
		}

		if (enemyFire.emissionRate < 0) {
			enemyFire.emissionRate = 0.0f;
		}

	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();
		print (body.tag);
		if (body.tag == "Enemy") {
			enemyFire.emissionRate += 0.01f;
			fireTimer = 0.0f;
		}

	}
}
