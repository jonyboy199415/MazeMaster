using UnityEngine;
using System.Collections;

public class FlamethrowerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();
		print (body);
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
