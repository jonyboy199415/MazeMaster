using UnityEngine;
using System.Collections;

public class IceBlastCollision : MonoBehaviour {

	public ParticleSystem fireFire1;
	public ParticleSystem fireFire2;
	public ParticleSystem fireFire3;
	public ParticleSystem fireFire4;
	public ParticleSystem fireFire5;

	private GameObject FireEthan1;
	private GameObject FireEthan2;
	private GameObject FireEthan3;
	private GameObject FireEthan4;
	private GameObject FireEthan5;

	private float fireTimer1;
	private float fireTimer2;
	private float fireTimer3;
	private float fireTimer4;
	private float fireTimer5;

	// Use this for initialization
	void Start () {
		FireEthan1 = GameObject.Find ("Fire_Ethan1");
		FireEthan2 = GameObject.Find ("Fire_Ethan2");
		FireEthan3 = GameObject.Find ("Fire_Ethan3");
		FireEthan4 = GameObject.Find ("Fire_Ethan4");
		FireEthan5 = GameObject.Find ("Fire_Ethan5");

		fireFire1.emissionRate = 10.0f;
		fireFire2.emissionRate = 10.0f;
		fireFire3.emissionRate = 10.0f;
		fireFire4.emissionRate = 10.0f;
		fireFire5.emissionRate = 10.0f;

		fireTimer1 = 0.0f;
		fireTimer2 = 0.0f;
		fireTimer3 = 0.0f;
		fireTimer4 = 0.0f;
		fireTimer5 = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		fireTimer1 += Time.deltaTime;
		fireTimer2 += Time.deltaTime;
		fireTimer3 += Time.deltaTime;
		fireTimer4 += Time.deltaTime;
		fireTimer5 += Time.deltaTime;

		//Fire Ethan 1
		if (fireTimer1 > 10) {
			fireFire1.emissionRate += 0.05f;
		}
		if (fireFire1.emissionRate > 10f) {
			fireFire1.emissionRate = 10.0f;
		}
		if (fireFire1.emissionRate <= 0f) {
			FireEthan1.SetActive (false);
		}

		//Fire Ethan 2
		if (fireTimer2 > 10) {
			fireFire2.emissionRate += 0.05f;
		}
		if (fireFire2.emissionRate > 10f) {
			fireFire2.emissionRate = 10.0f;
		}
		if (fireFire2.emissionRate <= 0f) {
			FireEthan2.SetActive (false);
		}

		//Fire Ethan 3
		if (fireTimer3 > 10) {
			fireFire3.emissionRate += 0.05f;
		}
		if (fireFire3.emissionRate > 10f) {
			fireFire3.emissionRate = 10.0f;
		}
		if (fireFire3.emissionRate <= 0f) {
			FireEthan3.SetActive (false);
		}

		//Fire Ethan 4
		if (fireTimer4 > 10) {
			fireFire4.emissionRate += 0.05f;
		}
		if (fireFire4.emissionRate > 10f) {
			fireFire4.emissionRate = 10.0f;
		}
		if (fireFire4.emissionRate <= 0f) {
			FireEthan4.SetActive (false);
		}

		//Fire Ethan 5
		if (fireTimer5 > 10) {
			fireFire5.emissionRate += 0.05f;
		}
		if (fireFire5.emissionRate > 10f) {
			fireFire5.emissionRate = 10.0f;
		}
		if (fireFire5.emissionRate <= 0f) {
			FireEthan5.SetActive (false);
		}
	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();

		if (body.tag == "FireEthan1") {
			fireFire1.emissionRate -= 2.0f;
			fireTimer1 = 0.0f;
		}

		if (body.tag == "FireEthan2") {
			fireFire2.emissionRate -= 2.0f;
			fireTimer2 = 0.0f;
		}

		if (body.tag == "FireEthan3") {
			fireFire3.emissionRate -= 2.0f;
			fireTimer3 = 0.0f;
		}

		if (body.tag == "FireEthan4") {
			fireFire4.emissionRate -= 2.0f;
			fireTimer4 = 0.0f;
		}

		if (body.tag == "FireEthan5") {
			fireFire5.emissionRate -= 2.0f;
			fireTimer5 = 0.0f;
		}
	}
}
