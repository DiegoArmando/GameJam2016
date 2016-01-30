using UnityEngine;
using System.Collections;

public class Overlap : MonoBehaviour {

	public bool overlap = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D()
	{
		overlap = true;
	}

	void OnTriggerLeave2D()
	{
		overlap = false;
	}

	bool CheckOverlap()
	{
		return overlap;
	}
}
