using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    private bool isPaused = false;
    public Canvas pauseMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print (GameObject.Find("FountainShop").GetComponent<Canvas>().enabled);
		if (Input.GetKeyDown("escape") && !isPaused && !(GameObject.Find("FountainShop").GetComponent<Canvas>().enabled))//PAUSE
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Input.GetKeyDown("escape") && isPaused)//UNPAUSE
        {
            pauseMenu.enabled = false;
            Time.timeScale = 1;
            isPaused = false;
        }
    
	
	}
    public void resumeClick()//Unpuse
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        isPaused = false;

    }
    public void exitClick()//Unpuse
    {
        Application.Quit();

    }
}
