using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideThese : MonoBehaviour {

	public List<GameObject> hideMe = new List<GameObject>();

	// Use this for initialization
	void Start () {
		foreach (GameObject g in hideMe) {
			g.GetComponent<SpriteRenderer> ().enabled = false;
		}

	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
