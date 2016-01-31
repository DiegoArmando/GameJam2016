using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideThese : MonoBehaviour {

	public List<GameObject> hideMe = new List<GameObject>();

	// Use this for initialization
	void Start () {
		hideAll ();
	}

	public void hideAll()
	{
		foreach (GameObject g in hideMe) {
			g.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	public void showPointers(string input)
	{
		switch (input) {
		case "staff":
			hideMe[9].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		case "snuff":
		case "light":
			hideMe[10].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe[11].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe[12].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe[13].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		case "book":
			hideMe[0].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		case "read":
			hideMe[1].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		case "food":
			hideMe[8].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		case "pool":
		case "feed":
			hideMe[7].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		case "bop":
			hideMe [2].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe [3].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe [4].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe [5].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe [6].GetComponent<SpriteRenderer> ().enabled = true;
			hideMe [14].GetComponent<SpriteRenderer> ().enabled = true;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
