using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

	public GameObject player;
	Move playerMovement;

	// Use this for initialization
	void Start () {
	
		playerMovement = player.GetComponent<Move>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (playerMovement.running) {
			this.transform.localScale += new Vector3(5.0f, 0,0) * Time.deltaTime;
		}
	}
}
