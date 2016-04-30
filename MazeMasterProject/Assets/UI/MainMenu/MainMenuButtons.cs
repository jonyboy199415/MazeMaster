using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {
	public GameObject TitleScreen;
	public GameObject CreditsScreen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void startClick()
    {
        Application.LoadLevel("HubArea");
    }
    public void creditsClick()//change to the credits canvas
    {
		TitleScreen.SetActive (false);
		CreditsScreen.SetActive (true);
    }
	public void BackClick()//change to the credits canvas
	{
		TitleScreen.SetActive (true);
		CreditsScreen.SetActive (false);
	}
    public void exitClick()
    {
        Application.Quit();
    }
}
