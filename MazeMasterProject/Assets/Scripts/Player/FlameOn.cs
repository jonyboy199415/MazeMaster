using UnityEngine;
using System.Collections;

public class FlameOn : MonoBehaviour {

	public ParticleSystem flames;
	private bool flameOn;

	public bool fireActive;

	public GameObject point;

	// Use this for initialization
	void Awake () {
		flames.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fireActive) {
			if (Input.GetKey (KeyCode.E)) {
				flames.Play ();
				flameOn = true;
				flames.emissionRate = 100f;
			} else {
				flameOn = false;
				flames.emissionRate = 0.0f;
			}
		}
			
		flames.startRotation = point.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
	}

}
