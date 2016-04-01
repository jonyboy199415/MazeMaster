using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void startClick()
    {
        Application.Quit();//Change to load the scene
    }
    public void creditsClick()//change to the credits canvas
    {
        Application.Quit();
    }
    public void exitClick()
    {
        Application.Quit();
    }
}
