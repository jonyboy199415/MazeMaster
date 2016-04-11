using UnityEngine;
using System.Collections;

public class FlamethrowerCollision : MonoBehaviour {

	public ParticleSystem iceFire1;
	public ParticleSystem iceFire2;
	public ParticleSystem iceFire3;
	public ParticleSystem iceFire4;
	public ParticleSystem iceFire5;
	public ParticleSystem fireFire6;
	public ParticleSystem fireFire7;
	public ParticleSystem fireFire8;
	public ParticleSystem fireFire9;
	public ParticleSystem fireFire10;
	private GameObject IceEthan1;
	private GameObject IceEthan2;
	private GameObject IceEthan3;
	private GameObject IceEthan4;
	private GameObject IceEthan5;

	private float fireTimer1;
	private float fireTimer2;
	private float fireTimer3;
	private float fireTimer4;
	private float fireTimer5;

	// Use this for initialization
	void Awake () {
		IceEthan1 = GameObject.Find ("Ice_Ethan1");
		IceEthan2 = GameObject.Find ("Ice_Ethan2");
		IceEthan3 = GameObject.Find ("Ice_Ethan3");
		IceEthan4 = GameObject.Find ("Ice_Ethan4");
		IceEthan5 = GameObject.Find ("Ice_Ethan5");

		iceFire1.emissionRate = 0.0f;
		iceFire2.emissionRate = 0.0f;
		iceFire3.emissionRate = 0.0f;
		iceFire4.emissionRate = 0.0f;
		iceFire5.emissionRate = 0.0f;

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

		//Ice Ethan 1
		if (fireTimer1 > 10) {
			iceFire1.emissionRate -= 0.05f;
		}
		if (iceFire1.emissionRate < 0) {
			iceFire1.emissionRate = 0.0f;
		}
		if (iceFire1.emissionRate >= 3f) {
			IceEthan1.SetActive (false);
		}

		//Ice Ethan 2
		if (fireTimer2 > 10) {
			iceFire2.emissionRate -= 0.05f;
		}
		if (iceFire2.emissionRate < 0) {
			iceFire2.emissionRate = 0.0f;
		}
		if (iceFire2.emissionRate >= 3f) {
			IceEthan2.SetActive (false);
		}

		//Ice Ethan 3
		if (fireTimer3 > 10) {
			iceFire3.emissionRate -= 0.05f;
		}
		if (iceFire3.emissionRate < 0) {
			iceFire3.emissionRate = 0.0f;
		}
		if (iceFire3.emissionRate >= 3f) {
			IceEthan3.SetActive (false);
		}

		//Ice Ethan 4
		if (fireTimer4 > 10) {
			iceFire4.emissionRate -= 0.05f;
		}
		if (iceFire4.emissionRate < 0) {
			iceFire4.emissionRate = 0.0f;
		}
		if (iceFire4.emissionRate >= 3f) {
			IceEthan4.SetActive (false);
		}

		//Ice Ethan 5
		if (fireTimer5 > 10) {
			iceFire5.emissionRate -= 0.05f;
		}
		if (iceFire5.emissionRate < 0) {
			iceFire5.emissionRate = 0.0f;
		}
		if (iceFire5.emissionRate >= 3f) {
			IceEthan5.SetActive (false);
		}
	}

	void OnParticleCollision(GameObject other){
		Rigidbody body = other.GetComponent<Rigidbody> ();

		if (body.tag == "IceEthan1") {
			iceFire1.emissionRate += 0.01f;
			fireTimer1 = 0.0f;
		}

		if (body.tag == "IceEthan2") {
			iceFire2.emissionRate += 0.01f;
			fireTimer2 = 0.0f;
		}

		if (body.tag == "IceEthan3") {
			iceFire3.emissionRate += 0.01f;
			fireTimer3 = 0.0f;
		}

		if (body.tag == "IceEthan4") {
			iceFire4.emissionRate += 0.01f;
			fireTimer4 = 0.0f;
		}

		if (body.tag == "IceEthan5") {
			iceFire5.emissionRate += 0.01f;
			fireTimer5 = 0.0f;
		}

	}
}
