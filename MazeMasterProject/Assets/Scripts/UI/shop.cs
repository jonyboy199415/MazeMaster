using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shop : MonoBehaviour {
	public Text ShopMoney;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShopMoney.text ="Stored Loot: "+GameManager.Manager.StoredLoot;
		if (Input.GetKeyUp ("escape")) {
			DeActivate ();
		}
	}

	public void scrollClick(){//increase health
		if (GameManager.Manager.StoredLoot > 500) { //if the stored loot is greater than the cost of the item
			GameManager.Manager.StoredLoot -= 500; //decrement the storedloot
			GameManager.Manager.MaxPlayerHealth += 50f;//increment the power up
		}
	}
	public void amuletClick(){//increase stamina
		if (GameManager.Manager.StoredLoot > 500) {
			GameManager.Manager.StoredLoot -= 500;
			GameManager.Manager.MaxPlayerStam += 50f;
		}
	}
	public void boneAmuletClick(){
		if (GameManager.Manager.StoredLoot > 500) {
			GameManager.Manager.StoredLoot  -= 500;
            GameManager.Manager.FirePower += 50f;
		}
	}
	public void statueClick(){
		if (GameManager.Manager.StoredLoot > 500) {
			GameManager.Manager.StoredLoot -= 500;
            GameManager.Manager.IcePower += 50f;
        }
	}
	public void ringClick(){
		if (GameManager.Manager.StoredLoot > 500) {
			GameManager.Manager.StoredLoot -= 500;
            GameManager.Manager.FireCost -= 50f;
        }
	}
	public void octopusClick(){
		if (GameManager.Manager.StoredLoot > 500) {
			GameManager.Manager.StoredLoot  -= 500;
            GameManager.Manager.IceCost -= 50f;
        }
	}
	public void Activate()
	{
		gameObject.GetComponent<Canvas> ().enabled = true;
		Time.timeScale = 0;
	}
	public void DeActivate()
	{
		gameObject.GetComponent<Canvas> ().enabled = false;
		Time.timeScale = 1;
	}
}
