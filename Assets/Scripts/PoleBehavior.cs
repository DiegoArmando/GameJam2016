using UnityEngine;
using System.Collections;

public class PoleBehavior : MonoBehaviour {

	public GameObject player;
	Vector3 initialPos;
	public bool held = false;


	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (held) {
			transform.position = player.transform.position - new Vector3 (1.0f, 0, 0);
		}
	}

	void PickUp()
	{
		held = true;
		sprite.sortingLayerName = "Held Object";
	}

	void PutDown()
	{
		held = false;
		transform.position = initialPos;
		sprite.sortingLayerName = "Interactable";
	}
}
