using UnityEngine;
using System.Collections;

public class IceCombat : MonoBehaviour {

	private GameObject IceEthan;
	private ParticleSystem ice;

	public bool onFire;

	// Use this for initialization
	void Start () {
		IceEthan = this.gameObject;
		ice = IceEthan.GetComponent<ParticleSystem> ();
		onFire = false;
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
