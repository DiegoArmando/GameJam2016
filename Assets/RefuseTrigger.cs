using UnityEngine;
using System.Collections;

public class RefuseTrigger : MonoBehaviour {

	public GameObject player;
	public GameObject preRefuse;
	public GameObject postRefuse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(){
		if (player.GetComponent<Move> ().fishFed) {
			preRefuse.GetComponent<SpriteRenderer> ().sprite = postRefuse.GetComponent<SpriteRenderer> ().sprite;
		}
	}
}
