using UnityEngine;
using System.Collections;
using UnityEngine .SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour {
	public GameObject PlayerPrefab;
	public GameObject Player;
	public GameObject Spawn;
	public float MaxPlayerHealth=100f;
	public float MaxPlayerStam=100f;
	public float PlayerHealth=100f;
	public float PlayerStam=100f;
	public float FirePower;
	public float IcePower;
	public float FireCost;
	public float IceCost;
	public float SprintCost;
	public int CurrentLoot;
	public int StoredLoot;
	public float HealthRatio = 1.0f;
	public float StamRatio = 1.0f;
	public string LastScene="MainMenu";

	public bool IsStunted = false;

	private SpriteRenderer fade;

	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player");
		fade = Player.GetComponentInChildren<SpriteRenderer> ();

		if (fade) {
			fade.color = new Color (fade.color.r, fade.color.g, fade.color.b, 0.0f);
		} else {
			print ("Doesn't exist");
		}
	}

	void Update(){
		if(Player==null)
			Player = GameObject.FindGameObjectWithTag ("Player");
		if (Input.GetKeyUp(KeyCode.M)) {
			TransferToHub ();
		}
		if (Input.GetKeyUp(KeyCode.N)) {
			Destroy(gameObject);
			Destroy (Player);
			TransferToMenu ();
		}
		if (Input.GetKeyUp(KeyCode.H)) {
			PlayerTakeDamage (5);
		}
		if (Input.GetKeyUp(KeyCode.G)) {
			PlayerLoseStam (5);
		}
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (Player);
		if (PlayerStam < MaxPlayerStam) {
			PlayerStam += Time.deltaTime * 20f;
			if (PlayerStam >= MaxPlayerStam) {
				IsStunted = false;
			}
		}
		HealthRatio = PlayerHealth / MaxPlayerHealth;
		StamRatio = PlayerStam / MaxPlayerStam;
		if (fade) {
			fade.color = new Color (fade.color.r, fade.color.g, fade.color.b, (HealthRatio-1) * -1);
			print (HealthRatio);
		}
	}

	void OnLevelWasLoaded(int Level)
	{
		if (Level == 0) {
		}
		if (Level == 1) {
			//Player.SetActive (true);
			Player = GameObject.FindGameObjectWithTag ("Player");
			if (LastScene == "MainMenu") {
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
				Player.transform.rotation = new Quaternion (0, 180, 0, 0);
			} else if (LastScene == "Maze1") {
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint2");
				Player.transform.rotation = new Quaternion (0, 270, 0, 0);
			} else if (LastScene == "Maze2") {
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint3");
				Player.transform.rotation = new Quaternion (0, 90, 0, 0);
			}else if(LastScene== "Maze3"){
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint4");
				Player.transform.rotation = new Quaternion(0,0,0,0);
			}
			Player.transform.position = Spawn.transform.position;
			//Player.transform.rotation = new Quaternion(Spawn.transform.rotation.x,Spawn.transform.rotation.y,Spawn.transform.rotation.z,Spawn.transform.rotation.w);
			Player.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
		}
		if (Level == 2) {
			//Player.SetActive (true);
			Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
			Player.transform.position = Spawn.transform.position;
			Player.transform.rotation = Spawn.transform.rotation;
			Player.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
		}
		if (Level == 3) {
			//Player.SetActive (true);
			Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
			Player.transform.position = Spawn.transform.position;
			Player.transform.rotation= Spawn.transform.rotation;
			Player.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
		}
		if (Level == 4) {
			//Player.SetActive (true);
			Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
			Player.transform.position = Spawn.transform.position;
			Player.transform.rotation = Spawn.transform.rotation;
			Player.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
		}
	}


	public void TransferToMenu()
	{

		SceneManager.LoadSceneAsync("MainMenu");

	}
	public void TransferToHub()
	{
		
		SceneManager.LoadSceneAsync ("HubArea");
	}

	public void TransferToMaze1()
	{
		SceneManager.LoadScene ("Level1");
	}
	public void TransferToMaze2()
	{
		SceneManager.LoadScene ("Level 2");
	}
	public void TransferToMaze3()
	{
		SceneManager.LoadScene ("Level3");
	}
	public void TransferToMaze4()
	{
	}

	public void SaveGame ()
	{
		PlayerPrefs.SetFloat ("MaxPlayerHealth", MaxPlayerHealth);
	}
	public void LoadGame ()
	{
		MaxPlayerHealth = PlayerPrefs.GetInt ("MaxPlayerHealth");
	}
	public void PlayerTakeDamage (float Damage)
	{
		PlayerHealth -= Damage;
		if (PlayerHealth <= 0f) {
			respawn ();
			CurrentLoot -= 20;
		}
	}
	public void PlayerLoseStam (float Loss)
	{
		if (!IsStunted) {
			if (PlayerStam > 0f) {
				PlayerStam -= Loss;
				if (PlayerStam < 0f) {
					IsStunted = true;
					PlayerStam = 0f;
				}
			}
		}
	}
	public void respawn()
	{
		Player.transform.position = Spawn.transform.position;
		Player.transform.rotation = Spawn.transform.rotation;
		Player.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
		PlayerHealth = MaxPlayerHealth;
	}

	public void addScore(int amount)
	{
		CurrentLoot += amount;
	}

	public void addStoredLoot(int amount)
	{
		StoredLoot += amount;
	}
}
