using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

	public GameObject player;
	Move playerMovement;
	float disapproval;

	Vector3 initialPosition;

	// Use this for initialization
	void Start () {
	
		playerMovement = player.GetComponent<Move>();
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (disapproval > 0) {
			disapproval -= 1 *Time.deltaTime;
		}
	
		this.transform.position = initialPosition + new Vector3(disapproval, 0,0);
	
		if (playerMovement.running) {
			disapproval += 5 * Time.deltaTime;
		}
	}
}
