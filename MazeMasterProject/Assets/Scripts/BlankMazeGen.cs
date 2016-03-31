using UnityEngine;
using System.Collections;

public class BlankMazeGen : MonoBehaviour {
	public GameObject HedgePiece;
	public int Height;
	public int width;

	private Vector3 Position;
	// Use this for initialization
	void Start () {
		//Position = new Vector3 (-20, 0,-20);
		for(int i=0; i < width;i++){
			for (int j = 0; j < Height; j++) {
				GameObject Temp = Instantiate(HedgePiece,new Vector3(0+i*2,0,0+j*2),this.transform.rotation) as GameObject; 
				Temp.transform.parent = GameObject.Find("MazeBlank").transform;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
