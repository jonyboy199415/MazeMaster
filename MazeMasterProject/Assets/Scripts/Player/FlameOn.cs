using UnityEngine;
using System.Collections;

public class FlameOn : MonoBehaviour {

	public ParticleSystem flames;
	private bool flameOn;

	public bool fireActive;
	public bool fireSet;

	public GameObject point;

	// Use this for initialization
	void Awake () {
		flames.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().PlayerStam > 0 && !GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().IsStunted) {
			fireActive = true;
		} else {
			fireActive = false;
		}

		if (fireActive && fireSet) {
			if (Input.GetKey (KeyCode.E)) {
				flames.Play ();
				flameOn = true;
				flames.emissionRate = 100f;
				GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().PlayerLoseStam (1.5f);
			} else {
				flameOn = false;
				flames.emissionRate = 0.0f;
			}
		} else {
			flames.emissionRate = 0.0f;
		}
			
		flames.startRotation = point.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
	}

}
