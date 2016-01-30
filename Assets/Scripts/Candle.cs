using UnityEngine;
using System.Collections;

public class Candle : MonoBehaviour {

	public GameObject litReference;
	public bool lit = false;
	Sprite litSprite;


	Sprite unlitSprite;

	// Use this for initialization
	void Start () {

		litSprite = litReference.GetComponent<SpriteRenderer> ().sprite;

		unlitSprite = GetComponent<SpriteRenderer>().sprite;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Action()
	{
		if (!lit)
			Light ();
		else
			Unlight ();
	}

	void Light()
	{
		lit = true;
		GetComponent<SpriteRenderer> ().sprite = litSprite;
	}

	void Unlight()
	{
		lit = false;
		GetComponent<SpriteRenderer> ().sprite = unlitSprite;
	}
}
