﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HudScript : MonoBehaviour {
	public int Score;
	public int StoredLoot;

	public Text lootCounter;
	public Text StoredLootCounter;
	public Image Boost1;
	public Image Boost2;
	public Image Boost3;
    public float timer;
    public Text timerT;
	// Use this for initialization
	void Start () 
	{
		Score = 0;
		Cursor.lockState = CursorLockMode.Locked;
        timer = 120;
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		lootCounter.text = "Loot On Hand: " + Score;
		StoredLootCounter.text = "Loot In Box " + StoredLoot;

        timer -= Time.deltaTime;

        timerT.text = "Time: " + timer;
        if (timer <= 0)
        {
            Application.LoadLevel(0);
        }
		if(Input.GetKeyUp(KeyCode.Alpha7))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().Boost1State(true);
		}
		if(Input.GetKeyUp(KeyCode.Alpha8))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().Boost2State(true);
		}
		if(Input.GetKeyUp(KeyCode.Alpha9))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().Boost3State(true);
		}
		if(Input.GetKeyUp(KeyCode.Alpha0))
		{
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().Boost1State(false);
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().Boost2State(false);
			GameObject.FindWithTag("HUD").GetComponent<HudScript>().Boost3State(false);
		}


	}
	public void addScore(int amount)
	{
		Score = Score + amount;
	}
	public void addStoredLoot(int amount)
	{
		StoredLoot = StoredLoot + amount;
	}
	public void Boost1State(bool State)
	{
		if (State == true) 
		{
			Boost1.color =new Color(255,0,0,255);
		}
		if (State == false) 
		{
			Boost1.color =new Color(255,0,0,.25f);
		}
	}
	public void Boost2State(bool State)
	{
		if (State == true) 
		{
			Boost2.color =new Color(0,0,255,255);
		}
		if (State == false) 
		{
			Boost2.color =new Color(0,0,255,.25f);
		}
		
	}
	public void Boost3State(bool State)
	{
		if (State == true) 
		{
			Boost3.color =new Color(0,255,0,255);
		}
		if (State == false) 
		{
			Boost3.color =new Color(0,255,0,.25f);
		}
		
	}
}
