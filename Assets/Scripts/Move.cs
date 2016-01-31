using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float speed;
	public bool running = false;
	bool holding = false;

	public GameObject pole;
	public GameObject poleHome;
	public GameObject organ;
	public GameObject candle1;
	public GameObject candle2;
	public GameObject candle3;
	public GameObject candle4;

	public GameObject food;
	public GameObject foodSpot;
	public GameObject book;
	public GameObject bookHome;
	public GameObject readPlace;

	public GameObject pish;
	public GameObject heldPish;

	float timer = 4.0f;
	bool waiting = false;

	//public GameObject candle1;
	//public 

	bool fishFed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (waiting)
			timer -= Time.deltaTime;
	
		if (timer <= 0)
			waiting = false;

		if (transform.position.y > 2.9)
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "Behind Stuff";
		}
		else 
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "People";
		}

		speed = 2.0f;
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed *= 2.0f;
			running = true;
		}
		else
		{
			running = false;
		}

		if (Input.GetKey (KeyCode.A)) {
			this.gameObject.transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
			if (waiting) {
				waiting = false;
				//bug priest here
			}
		}

		if (Input.GetKey (KeyCode.D)) {
			this.gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

			if (waiting) {
				waiting = false;
				//bug priest here
			}
		}

		if (Input.GetKey (KeyCode.W)) {
			this.gameObject.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;

			if (waiting) {
				waiting = false;
				//bug priest here
			}
		}

		if (Input.GetKey (KeyCode.S)) {
			this.gameObject.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;

			if (waiting) {
				waiting = false;
				//bug priest here
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{

			if (poleHome.GetComponent<Overlap>().overlap)
			{
				if (pole.GetComponent<PoleBehavior> ().held)
				{
					//print ("We should be putting down the pole now");
					pole.SendMessage ("PutDown");
					holding = false;
				}
				else
				{
					pole.SendMessage ("PickUp");
					holding = true;
				}
			}

			if (organ.GetComponent<Overlap>().overlap)
			{
				GetComponent<AudioSource> ().Play (0);
				//AudioSource.PlayClipAtPoint( new AudioClip(
			}

			if (candle1.GetComponent<Overlap> ().overlap)
			{
				if (pole.GetComponent<PoleBehavior> ().held) 
				{
					candle1.SendMessage ("Action");
				}
			}

			if (candle2.GetComponent<Overlap> ().overlap)
			{
				if (pole.GetComponent<PoleBehavior> ().held) 
				{
					candle2.SendMessage ("Action");
				}
			}

			if (candle3.GetComponent<Overlap> ().overlap)
			{
				if (pole.GetComponent<PoleBehavior> ().held) 
				{
					candle3.SendMessage ("Action");
				}
			}

			if (candle4.GetComponent<Overlap> ().overlap)
			{
				if (pole.GetComponent<PoleBehavior> ().held) 
				{
					candle4.SendMessage ("Action");
				}
			}

			if (food.GetComponent<Overlap> ().overlap) 
			{
				food.SendMessage ("PickUp");
				holding = true;
			}

			if (!fishFed) {
				if (foodSpot.GetComponent<Overlap> ().overlap && food.GetComponent<PoleBehavior> ().held) {
					fishFed = true;
					Destroy (food);
					print ("FFFFEEEED THE FEEEEESH");

					//Hide the pish
					pish.GetComponent<SpriteRenderer> ().enabled = false;
					heldPish.GetComponent<PoleBehavior> ().SendMessage ("PickUp");

				}
			}

			if (bookHome.GetComponent<Overlap> ().overlap) 
			{
				if (book.GetComponent<PoleBehavior>().held) 
				{
					book.GetComponent<PoleBehavior>().SendMessage ("PutDown");
					holding = false;
				} 
				else if(holding == false)
				{
					book.GetComponent<PoleBehavior>().SendMessage ("PickUp");
					holding = true;
				}

			}

			if (readPlace.GetComponent<Overlap>().overlap && book.GetComponent<PoleBehavior>().held) 
			{
				waiting = true;
			}

		}



	}
}
