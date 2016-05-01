using UnityEngine;
using System.Collections;

public class playMovement : MonoBehaviour {

	public float speed = 2.5f;
	public float jumpHeight = 250f;
	public float sensitivityX = 5f;
	public float sensitivityY = 5f;
	public Camera charCamera;
	Vector3 movement;
	Animator anim;
	Rigidbody playerBody;
	bool isFalling = false;
	bool isCrouching;
	private Vector3 vRotation;
	private bool isJumping;
	public float GroundDist=0.3f;

	void Awake()
	{
		anim = GetComponent<Animator>();
		playerBody = GetComponent<Rigidbody>();

	}

	void Start()
	{
		vRotation = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float v = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		transform.Translate (h, 0, v);

		vRotation.y = vRotation.y + Input.GetAxis ("Mouse X") * sensitivityX;
		vRotation.x = Mathf.Clamp (vRotation.x + Input.GetAxis ("Mouse Y") * sensitivityY, -60.0f, 60.0f);
		transform.localEulerAngles = new Vector3 (0, vRotation.y, 0);
		charCamera.transform.localEulerAngles = new Vector3 (-vRotation.x, 0, 0);

		animating ();
		//DontDestroyOnLoad (gameObject);
		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * GroundDist));
		#endif
		if (Physics.Raycast(transform.position+(Vector3.up * 0.1f), Vector3.down, out hitInfo, GroundDist)&&isJumping&&!Input.GetKey(KeyCode.Space))
		{
			isJumping = false;
		}
	}



	void animating ()
	{
		//play walking right animation
		if (Input.GetKey(KeyCode.D)) 
		{
			if(isCrouching == true)
			{
				anim.SetBool ("crouchWalkingR", true);
			}
			else
			{
			    anim.SetBool ("walkingR", true);
			}
		} 
		else 
		{
			anim.SetBool ("crouchWalkingR", false);
			anim.SetBool ("walkingR", false);
		}

		//play walking left animation
		if (Input.GetKey(KeyCode.A)) 
		{
			if(isCrouching == true)
			{
				anim.SetBool ("crouchWalkingL", true);
			}
			else
			{
		        anim.SetBool ("walkingL", true);
			}

		} 
		else 
		{
			anim.SetBool ("crouchWalkingL", false);
			anim.SetBool ("walkingL", false);
		}

		//play walking forward animation
		if (Input.GetKey(KeyCode.W)) 
		{
			if(isCrouching == true)
			{
				anim.SetBool ("crouchWalkingF", true);
			}
			else
			{
			   anim.SetBool ("walkingF", true);
			}
		} 
		else 
		{
			anim.SetBool ("crouchWalkingF", false);
			anim.SetBool ("walkingF", false);
		}

		//play walking back animation
		if (Input.GetKey(KeyCode.S)) 
		{
			if(isCrouching == true)
			{
				anim.SetBool ("crouchWalkingB", true);
			}
			else
			{
			   anim.SetBool ("walkingB", true);
			}
		} 
		else 
		{

			anim.SetBool ("crouchWalkingB", false);
			anim.SetBool ("walkingB", false);
		}

		//play courch animation
		if (Input.GetKeyDown (KeyCode.Z))
		{
			isCrouching = true;
			anim.SetBool ("isCrouch", true);
			speed = 1f;
		}
		else if(Input.GetKeyUp (KeyCode.Z)) 
		{
			isCrouching= false;
		    anim.SetBool ("isCrouch", false);
			speed = 3f;
		}

		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
		{
			if (!GameManager.Manager.IsStunted) {
				anim.SetBool ("running", true);
				speed = 5f;
				GameManager.Manager.PlayerLoseStam (1f);
			}
		}
		else if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool ("running", false);
			speed = 3f;
		}

		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			if (isJumping == false) {
				playerBody.AddForce (transform.up * jumpHeight);
				isJumping = true;
			}
		}


	}
	void OnTriggerEnter(Collider other){
		switch (other.tag) {
		case"Maze1Portal":
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().LastScene="Maze1";
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().TransferToMaze1();
			break;
		case"Maze2Portal":
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().LastScene="Maze2";
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().TransferToMaze2();
			break;
		case"Maze3Portal":
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().LastScene="Maze3";
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().TransferToMaze3();
			break;
		case"Maze4Portal":
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().LastScene="Maze4";
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().TransferToMaze4();
			break;
		case"HubPortal":
			GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ().TransferToHub();
			break;
		}
	}


//	void jump()
//	{
//		if(Input.GetKeyDown(KeyCode.K))
//		{
//			
//			playerBody.AddForce(transform.up*jumpHeight);
//			
//			
//		}
//	}


}
