using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

	public GameObject player;
	Move playerMovement;
	float disapproval = 0;

	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
	
		playerMovement = player.GetComponent<Move>();
		initialPosition = transform.position;
		print ("Initial pos: " + initialPosition.ToString ());
		print ("Dissaproval: " + disapproval.ToString ());
	}
	
	// Update is called once per frame
	void Update () {

		if (disapproval > 0) {
			disapproval -= 0.4f *Time.deltaTime;
		}
	
		this.transform.position = initialPosition + new Vector3(disapproval, 0,0);
	
		if (playerMovement.running) {
			disapproval += 1.5f * Time.deltaTime;
		}
	}
}
