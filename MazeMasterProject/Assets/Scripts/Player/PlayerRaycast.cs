using UnityEngine;
using System.Collections;

public class PlayerRaycast : MonoBehaviour {
    // intializes the score and then sets up the script variables to be called so we can change them to call animations.
	public float fReachDistance = 2.0f;
	//public ParticleSystem enemyFire;
	//public GameObject enemy;
	private GameObject cam;
	//private float fireTimer;

    // Use this for initialization
    void Start ()
    {
		cam = transform.FindChild ("Camera").gameObject;
		//fireTimer = 0.0f;
		//enemyFire.Pause ();
    }

    // Update is called once per frame
    void Update()
	{
		
        // intialises the hit raycast and hit. it creates ray and users mouse input to ray cast.
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, fReachDistance))
		{	
			if (Input.GetKey (KeyCode.E)) {
				switch (hit.collider.gameObject.tag) {
				case "goldCoin":
					collect (1, hit);
					break;
				case "ingot":
					collect (5, hit);
					break;
				case "Gem":
					collect (20, hit);
					break;
				case "LootHolder":
					GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().addStoredLoot (GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().CurrentLoot);
					collect (-GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().CurrentLoot, hit);
					GameObject.Find ("FountainShop").GetComponent<shop> ().Activate ();
					break;
				case "Safe":
					// if the collider is tied to safe tagged game object it will change the bool "Looted" in "ChestLogic>" script to true to open the safe
					hit.collider.gameObject.GetComponent<ChestLogic> ().Looted = true;
					break;
				case"RedKey":
					GameManager.Manager.RedKeys++;
					Destroy (hit.collider.gameObject);
					break;
				case"BlueKey":
					GameManager.Manager.BlueKeys++;
					Destroy (hit.collider.gameObject);
					break;
				case"GreenKey":
					GameManager.Manager.GreenKeys++;
					Destroy (hit.collider.gameObject);
					break;
				case"YellowKey":
					GameManager.Manager.YellowKeys++;
					Destroy (hit.collider.gameObject);
					break;
				case"OrangeKey":
					GameManager.Manager.OrangeKeys++;
					Destroy (hit.collider.gameObject);
					break;
				case"PurpleKey":
					GameManager.Manager.PurpleKeys++;
					Destroy (hit.collider.gameObject);
					break;
				case"RedDoor":
					if (GameManager.Manager.RedKeys > 0) {
						GameManager.Manager.RedKeys--;
						Destroy (hit.collider.gameObject);
					}
					break;
				case"BlueDoor":
					if (GameManager.Manager.BlueKeys > 0) {
						GameManager.Manager.BlueKeys--;
						Destroy (hit.collider.gameObject);
					}
					break;
				case"GreenDoor":
					if (GameManager.Manager.GreenKeys > 0) {
						GameManager.Manager.GreenKeys--;
						Destroy (hit.collider.gameObject);
					}
					break;
				case"YellowDoor":
					if (GameManager.Manager.YellowKeys > 0) {
						GameManager.Manager.YellowKeys--;
						Destroy (hit.collider.gameObject);
					}
					break;
				case"OrangeDoor":
					if (GameManager.Manager.OrangeKeys > 0) {
						GameManager.Manager.OrangeKeys--;
						Destroy (hit.collider.gameObject);
					}
					break;
				case"PurpleDoor":
					if (GameManager.Manager.PurpleKeys > 0) {
						GameManager.Manager.PurpleKeys--;
						Destroy (hit.collider.gameObject);
					}
					break;
				case "Turkey":
					GameManager.Manager.PlayerHealth+=50f;
					Destroy (hit.collider.gameObject);
					break;
				case "Apple":
					GameManager.Manager.PlayerHealth+=10f;
					Destroy (hit.collider.gameObject);
					break;
				/*case "Enemy":
					fireTimer += Time.deltaTime;
					if (fireTimer >= 3) {
						Invoke ("Kill", 5);
						setAblaze ();
					}
					break;*/
				default:
					break;
				} //End switch(hit.collider.gameObject.tag)
			} /*else {
				fireTimer = 0.0f;
			}*/
		} //End if (Physics.Raycast(ray, out hit))   

    }//End void Update()

	//TODO: enter function header
	//Collects the object and increments score.
	private void collect(int pPoints, RaycastHit pHit){
		GetComponent<CharacterStats> ().adjLoot (pPoints);
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().addScore(pPoints);
		if (pHit.collider.tag != "LootHolder")
		{
			Destroy (pHit.collider.gameObject);
		}
	} //End private void collect(int pPoints, RaycastHit pHit)

	void setAblaze(){
		//enemyFire.Play ();
	}

	void Kill(){
		//enemy.SetActive (false);
	}
} //End public class lootScriptGold : MonoBehaviour

