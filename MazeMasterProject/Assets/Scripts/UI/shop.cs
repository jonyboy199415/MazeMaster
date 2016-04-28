using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void scrollClick(){//increase health
		if (GameManager.StoredLoot > 500) { //if the stored loot is greater than the cost of the item
			GameManager.StoredLoot = GameManager.StoredLoot - 500; //decrement the storedloot
			GameManager.MaxPlayerHealth = GameManager.MaxPlayerHealth + 50f;//increment the power up
		}
	}
	public void amuletClick(){//increase stamina
		if (GameManager.StoredLoot > 500) {
			GameManager.StoredLoot = GameManager.StoredLoot - 500;
			GameManager.MaxPlayerStam = GameManager.MaxPlayerStam + 50f;
		}
	}
	public void boneAmuletClick(){
		if (GameManager.StoredLoot > 500) {
			GameManager.StoredLoot = GameManager.StoredLoot - 500;
		}
	}
	public void statueClick(){
		if (GameManager.StoredLoot > 500) {
			GameManager.StoredLoot = GameManager.StoredLoot - 500;
		}
	}
	public void ringClick(){
		if (GameManager.StoredLoot > 500) {
			GameManager.StoredLoot = GameManager.StoredLoot - 500;
		}
	}
	public void octopusClick(){
		if (GameManager.StoredLoot > 500) {
			GameManager.StoredLoot = GameManager.StoredLoot - 500;
		}
	}
		
}
