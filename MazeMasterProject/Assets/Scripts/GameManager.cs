using UnityEngine;
using System.Collections;
using UnityEngine .SceneManagement;

public class GameManager: MonoBehaviour {
	public GameObject PlayerPrefab;
	public GameObject Player;
	public GameObject Spawn;
	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		if (Input.GetKeyUp(KeyCode.M)) {
			TransferToHub ();
		}
		if (Input.GetKeyUp(KeyCode.N)) {
			Destroy(gameObject);
			Destroy (Player);
			TransferToMenu ();
		}
		DontDestroyOnLoad (gameObject);
	}

	void OnLevelWasLoaded(int Level)
	{
		if (Level == 0) {
		}
		else if (Level == 1) {
			Player.SetActive (true);
			Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
			Player.transform.position = (new Vector3 (Spawn.transform.position.x, Spawn.transform.position.y, Spawn.transform.position.z));
		}
	}


	public void TransferToMenu()
	{

		SceneManager.LoadSceneAsync("MainMenu");

	}
	public void TransferToHub()
	{
		SceneManager.LoadSceneAsync ("HubArea");
		Player.SetActive (true);
	}

	public void TransferToMaze1()
	{
	}
	public void TransferToMaze2()
	{
	}
	public void TransferToMaze3()
	{
	}
	public void TransferToMaze4()
	{
	}

}
