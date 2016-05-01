using UnityEngine;
using System.Collections;

public class FREEZE : MonoBehaviour {

	public ParticleSystem ice;
	private bool freezeOn;

	public bool iceActive;
	public bool iceSet;

	public GameObject point;

	// Use this for initialization
	void Start () {
		ice.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Manager.PlayerStam > 0 && !GameManager.Manager.IsStunted) {
			iceActive = true;
		} else {
			iceActive = false;
		}

		if (iceActive && GameManager.Manager.IsIce) {
			if (Input.GetMouseButtonDown(0)) {
				ice.Play ();
				freezeOn = true;
				ice.Emit (50);
				GameManager.Manager.PlayerLoseStam (30);
			} else {
				freezeOn = false;
			}
		} else {
			
		}

		ice.startRotation = point.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
	}
}
