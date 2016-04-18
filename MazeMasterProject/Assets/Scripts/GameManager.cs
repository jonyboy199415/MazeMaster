using UnityEngine;
using System.Collections;
using UnityEngine .SceneManagement;

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

	private bool IsStunted = false;

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
		if (Input.GetKeyUp(KeyCode.H)) {
			PlayerTakeDamage (5);
		}
		if (Input.GetKeyUp(KeyCode.G)) {
			PlayerLoseStam (5);
		}
		DontDestroyOnLoad (gameObject);
		if (PlayerStam < MaxPlayerStam) {
			PlayerStam += Time.deltaTime * 20f;
			if (PlayerStam >= MaxPlayerStam) {
				IsStunted = false;
			}
		}
		HealthRatio = PlayerHealth / MaxPlayerHealth;
		StamRatio = PlayerStam / MaxPlayerStam;
	}

	void OnLevelWasLoaded(int Level)
	{
		if (Level == 0) {
		}
		else if (Level == 1) {
			Player.SetActive (true);
			Spawn = GameObject.FindGameObjectWithTag ("SpawnPoint");
			Player.transform.position = (new Vector3 (Spawn.transform.position.x, Spawn.transform.position.y, Spawn.transform.position.z));
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
		Player.transform.position = (new Vector3 (Spawn.transform.position.x, Spawn.transform.position.y, Spawn.transform.position.z));
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
