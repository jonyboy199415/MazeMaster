using UnityEngine;
using System.Collections;
using UnityEngine.UI;


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
		Text Help =GameObject.FindGameObjectWithTag("HUD").GetComponent<HudScript>().HelperText;
		Text Help2 =GameObject.FindGameObjectWithTag("HUD").GetComponent<HudScript>().HelperText2;

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
					collect (20000, hit);
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
					if(GameManager.Manager.PlayerHealth<GameManager.Manager.MaxPlayerHealth)
						GameManager.Manager.PlayerHealth+=50f;
					if(GameManager.Manager.PlayerHealth>GameManager.Manager.MaxPlayerHealth)
						GameManager.Manager.PlayerHealth=GameManager.Manager.MaxPlayerHealth;
					Destroy (hit.collider.gameObject);
					break;
				case "Apple":
					if(GameManager.Manager.PlayerHealth<GameManager.Manager.MaxPlayerHealth)
						GameManager.Manager.PlayerHealth+=20f;
					if(GameManager.Manager.PlayerHealth>GameManager.Manager.MaxPlayerHealth)
						GameManager.Manager.PlayerHealth=GameManager.Manager.MaxPlayerHealth;
					Destroy (hit.collider.gameObject);
					break;
				case "FireOrb":
					GameManager.Manager.CanFire = true;
					GameManager.Manager.IsFire = true;
					GameManager.Manager.IsIce = false;
					Destroy (hit.collider.gameObject);
					break;
				case "IceOrb":
					GameManager.Manager.CanIce = true;
					GameManager.Manager.IsIce = true;
					GameManager.Manager.IsFire = false;
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





			} 
			Text Help =GameObject.FindGameObjectWithTag("ScreenOver").GetComponentInChildren<HudScript>().HelperText;
			Text Help2 =GameObject.FindGameObjectWithTag("ScreenOver").GetComponentInChildren<HudScript>().HelperText2;

			//print(hit.collider.gameObject.tag);
			//print(hit.collider.gameObject);

			switch (hit.collider.gameObject.tag) {
			case "goldCoin":
				Help.text = "Press: E to Gather Coin";
				Help2.text = "Press: E to Gather Coin";
				break;
			case "ingot":
				Help.text = "Press: E to Gather Bar";
				Help2.text = "Press: E to Gather Bar";
				break;
			case "Gem":
				Help.text = "Press: E to Gather Gem";
				Help2.text = "Press: E to Gather Gem";
				break;
			case "LootHolder":
				Help.text = "Press: E to Store loot and Access Shop";
				Help2.text = "Press: E to Store loot and Access Shop";
				break;
			case"RedKey":
				Help.text = "Press: E to pick Up Red Key";
				Help2.text = "Press: E to pick Up Red Key";
				break;
			case"BlueKey":
				Help.text = "Press: E to pick Up Blue Key";
				Help2.text = "Press: E to pick Up Blue Key";
				break;
			case"GreenKey":
				Help.text = "Press: E to pick Up Green Key";
				Help2.text = "Press: E to pick Up Green Key";
				break;
			case"YellowKey":
				Help.text = "Press: E to pick Up Yellow Key";
				Help2.text = "Press: E to pick Up Yellow Key";
				break;
			case"OrangeKey":
				Help.text = "Press: E to pick Up Orange Key";
				Help2.text = "Press: E to pick Up Orange Key";
				break;
			case"PurpleKey":
				Help.text = "Press: E to pick Up Purple Key";
				Help2.text = "Press: E to pick Up Purple Key";
				break;
			case"RedDoor":
				if (GameManager.Manager.RedKeys > 0) {
					Help.text = "Press: E to Unlock Red Gate";
					Help2.text = "Press: E to Unlock Red Gate";
				} else {
					Help.text = "You Need a Red Key to Unlock This Gate";
					Help2.text = "You Need a Red Key to Unlock This Gate";
				}
				break;
			case"BlueDoor":
				if (GameManager.Manager.BlueKeys > 0) {
					Help.text = "Press: E to Unlock Blue Gate";
					Help2.text = "Press: E to Unlock Blue Gate";
				} else {
					Help.text = "You Need a Blue Key to Unlock This Gate";
					Help2.text = "You Need a Blue Key to Unlock This Gate";
				}
				break;
			case"GreenDoor":
				if (GameManager.Manager.GreenKeys > 0) {
					Help.text = "Press: E to Unlock Green Gate";
					Help2.text = "Press: E to Unlock Green Gate";
				} else {
					Help.text = "You Need a Green Key to Unlock This Gate";
					Help2.text = "You Need a Green Key to Unlock This Gate";
				}
				break;
			case"YellowDoor":
				if (GameManager.Manager.YellowKeys > 0) {
					Help.text = "Press: E to Unlock Yellow Gate";
					Help2.text = "Press: E to Unlock Yellow Gate";
				} else {
					Help.text = "You Need a Yellow Key to Unlock This Gate";
					Help2.text = "You Need a Yellow Key to Unlock This Gate";
				}
				break;
			case"OrangeDoor":
				if (GameManager.Manager.OrangeKeys > 0) {
					Help.text = "Press: E to Unlock Orange Gate";
					Help2.text = "Press: E to Unlock Orange Gate";
				} else {
					Help.text = "You Need a Orange Key to Unlock This Gate";
					Help2.text = "You Need a Orange Key to Unlock This Gate";
				}
				break;
			case"PurpleDoor":
				if (GameManager.Manager.PurpleKeys > 0) {
					Help.text = "Press: E to Unlock Purple Gate";
					Help2.text = "Press: E to Unlock Purple Gate";
				} else {
					Help.text = "You Need a Purple Key to Unlock This Gate";
					Help2.text = "You Need a Purple Key to Unlock This Gate";
				}
				break;
			case "Turkey":
				Help.text = "Press: E to Eat Turkey";
				Help2.text = "Press: E to Eat Turkey";
				break;
			case "Apple":
				Help.text = "Press: E to Eat Apple";
				Help2.text = "Press: E to Eat Apple";
				break;
			case "FireOrb":
				Help.text = "Press: E Absorb Fire Orb and Unlock Fire Spell";
				Help2.text = "Press: E Absorb Fire Orb and Unlock Fire Spell";
				break;
			case "IceOrb":
				Help.text = "Press: E Absorb Ice Orb and Unlock Ice Spell";
				Help2.text = "Press: E Absorb Ice Orb and Unlock Ice Spell";
				break;
			case null:
				Help.text = "";
				Help2.text = "";
				break;
			default:
				Help.text = "";
				Help2.text = "";
				break;
			}

				

		}
		else
		{
			Text Help =GameObject.FindGameObjectWithTag("ScreenOver").GetComponentInChildren<HudScript>().HelperText;
			Text Help2 =GameObject.FindGameObjectWithTag("ScreenOver").GetComponentInChildren<HudScript>().HelperText2;

			Help.text = "";
			Help2.text = "";
		}
		//End if (Physics.Raycast(ray, out hit))   

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

