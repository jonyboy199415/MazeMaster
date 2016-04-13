using UnityEngine;
using System.Collections;

public class FREEZE : MonoBehaviour {

	public ParticleSystem ice;
	private bool freezeOn;

	private bool iceActive;

	public GameObject point;

	// Use this for initialization
	void Start () {
		ice.Pause ();
		iceActive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (iceActive) {
			if (Input.GetKey (KeyCode.E)) {
				ice.Play ();
				freezeOn = true;
				ice.Emit (50);
			} else {
				freezeOn = false;
			}
		}

		ice.startRotation = point.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
	}
}
