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

		if (flameOn) {
			print ("Time: " + Time.deltaTime);
		}
	}
}
