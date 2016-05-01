using UnityEngine;
using System.Collections;
using UnityEngine .SceneManagement;
using UnityEngine.UI;

public class GameManager: MonoBehaviour {
	public static GameManager Manager;
	//public GameObject PlayerPrefab;
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
	public int RedKeys;
	public int BlueKeys;
	public int GreenKeys;
	public int YellowKeys;
	public int OrangeKeys;
	public int PurpleKeys;
	public float HealthRatio = 1.0f;
	public float StamRatio = 1.0f;
	public string LastScene="MainMenu";
	public bool CanFire=false;
	public bool CanIce =false;
	public bool IsFire=false;
	public bool IsIce =false;

	public bool IsStunted = false;

	private Image redFade;
	private GameObject redFadeObject;
	void Awake()
	{
		if (Manager == null) 
		{
			DontDestroyOnLoad (gameObject);
			Manager = this;
		} else if (Manager != this) 
		{
			Destroy (gameObject);
		}


	}
	void Start(){
		//Player = GameObject.FindGameObjectWithTag ("Player");
		/*fade = Player.GetComponentInChildren<SpriteRenderer> ();

		if (fade) {
			fade.color = new Color (fade.color.r, fade.color.g, fade.color.b, 0.0f);
		} else {
			print ("Doesn't exist");
		}*/
	}

	void Update(){
		/*if(Player==null)
			Player = GameObject.FindGameObjectWithTag ("Player");*/
		if (Input.GetKeyUp(KeyCode.M)) {
			TransferToHub ();
			Player.transform.rotation = Spawn.transform.rotation;
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
		if (PlayerStam < MaxPlayerStam) {
			PlayerStam += Time.deltaTime * (MaxPlayerStam*0.1f);
			if (PlayerStam >= MaxPlayerStam) {
				IsStunted = false;
			}
		}
		HealthRatio = PlayerHealth / MaxPlayerHealth;
		StamRatio = PlayerStam / MaxPlayerStam;
		if (redFade) {
			redFade.color = new Color (redFade.color.r, redFade.color.g, redFade.color.b, (HealthRatio-1) * -1);
		}
		if (Input.GetKeyUp (KeyCode.Q)) {
			if (IsFire && CanIce) {
				IsFire=false;
				IsIce = true;
			}else if (IsIce && CanFire) {
				IsIce=false;
				if(CanFire)
					IsFire = true;
			}
		}
	}

	void OnLevelWasLoaded(int Level)
	{
		if (Level == 0) {
		}
		else if (Level == 1) {
			//Player.SetActive (true);
			//Instantiate(PlayerPrefab);
			redFadeObject = GameObject.FindGameObjectWithTag ("RedFade");
			if (redFadeObject != null) {
				redFade = redFadeObject.GetComponent<Image> ();
				redFade.color = new Color (redFade.color.r, redFade.color.g, redFade.color.b, 0.0f);
			}
			Player = GameObject.FindGameObjectWithTag ("Player");
			if (LastScene == "MainMenu") {
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
				Player.transform.rotation = Spawn.transform.rotation;
			} else if (LastScene == "Maze1") {
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint2");
				Player.transform.rotation = Spawn.transform.rotation;
			} else if (LastScene == "Maze2") {
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint3");
				Player.transform.rotation = Spawn.transform.rotation;
			}else if(LastScene== "Maze3"){
				Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint4");
				Player.transform.rotation = Spawn.transform.rotation;
			}
			Player.transform.position = Spawn.transform.position;
		}else{
			redFadeObject = GameObject.FindGameObjectWithTag ("RedFade");
			if (redFadeObject != null) {
				redFade = redFadeObject.GetComponent<Image> ();
				redFade.color = new Color (redFade.color.r, redFade.color.g, redFade.color.b, 0.0f);
			}
			Player = GameObject.FindGameObjectWithTag ("Player");
			Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
			Player.transform.position = Spawn.transform.position;
			Player.transform.rotation = Spawn.transform.rotation;
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
			if (CurrentLoot >= 0) {
				CurrentLoot -= 20;
			}if (CurrentLoot < 0) {
				CurrentLoot = 0;
			}
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
