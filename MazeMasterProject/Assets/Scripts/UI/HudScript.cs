using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HudScript : MonoBehaviour {
	public int Score;
	public int StoredLoot;

	public Text lootCounter;
	//public Text StoredLootCounter;
	public Image HealthBar;
	public Image StamBar;
	public Text RedKeycounter;
	public Text BlueKeycounter;
	public Text GreenKeycounter;
	public Text YellowKeycounter;
	public Text OrangeKeycounter;
	public Text PurpleKeycounter;
	public Text WhiteKeycounter;
	public Text BlackKeycounter;
	public Text HelperText;
	public Text HelperText2;
	public GameObject WinScreen;
	//public Image Boost1;
	//public Image Boost2;
	//public Image Boost3;
    //public float timer;
    //public Text timerT;
	// Use this for initialization
	void Start () 
	{
		Score = 0;
		//Cursor.lockState = CursorLockMode.Locked;
        //timer = 120;
	}
	
	// Update is called once per frame
	void Update () {
		lootCounter.text = "Loot: " + GameManager.Manager.CurrentLoot;
		HealthBar.transform.localScale=new Vector3(GameManager.Manager.HealthRatio,1f,1f);
		StamBar.transform.localScale=new Vector3(GameManager.Manager.StamRatio,1,1);
		RedKeycounter.text = ""+GameManager.Manager.RedKeys;
		BlueKeycounter.text = ""+GameManager.Manager.BlueKeys;
		GreenKeycounter.text = ""+GameManager.Manager.GreenKeys;
		YellowKeycounter.text = ""+GameManager.Manager.YellowKeys;
		OrangeKeycounter.text = ""+GameManager.Manager.OrangeKeys;
		PurpleKeycounter.text = ""+GameManager.Manager.PurpleKeys;
		WhiteKeycounter.text = ""+GameManager.Manager.WhiteKeys;
		BlackKeycounter.text = ""+GameManager.Manager.BlackKeys;
	}
	public void Win()
	{
		WinScreen.SetActive (true);
	}
	public void OnMenuClick(){
		GameManager.Manager.TransferToMenu();
	}


	/*public void Boost1State(bool State)
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
		
	}*/
}
