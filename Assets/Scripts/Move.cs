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
	public GameObject foodHome;
	public GameObject book;
	public GameObject bookHome;
	public GameObject readPlace;

	public GameObject pish;
	public GameObject heldPish;

	public GameObject bop1;
	public GameObject bop2;
	public GameObject bop3;
	public GameObject bop4;
	public GameObject bop5;
	public GameObject bop6;

	public GameObject boppee1;
	public GameObject boppee2;
	public GameObject boppee3;
	public GameObject boppee4;
	public GameObject boppee5;
	public GameObject boppee6;

	public GameObject postBop1;
	public GameObject postBop2;
	public GameObject postBop3;
	public GameObject refuseBop;
	public GameObject postBop5;
	public GameObject postBop6;

	public GameObject bopSprite;
	Sprite originalFish;

	float bopTimer = 0.34f;
	bool bopping = false;

	float timer = 4.0f;
	bool waiting = false;

	//public GameObject candle1;
	//public 

	public bool candlesLit = false;
	public bool bookRead = false;
	public bool fishFed = false;
	public bool peopleBopped = false;
	public bool candlesUnlit = false;

	bool fadeChant = false;

	// Use this for initialization
	void Start () {
		originalFish = heldPish.GetComponent<SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void Update () {

		if (candlesUnlit) {
			//End the game
		}

		if (waiting)
			timer -= Time.deltaTime;
	
		if (timer <= 0) {
			waiting = false;
			bookRead = true;
		}

		if (fadeChant && heldPish.GetComponent<AudioSource> ().volume > 0) {
			heldPish.GetComponent<AudioSource> ().volume -= Time.deltaTime / 3.0f;
		}

		if (transform.position.y > 2.9)
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "Behind Stuff";
		}
		else 
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "People";
		}

		speed = 5.0f;

		if (heldPish.GetComponent<PoleBehavior> ().held) {
			speed = 3.0f;
		}


		if (bopping) {
			heldPish.GetComponent<SpriteRenderer> ().sprite = bopSprite.GetComponent<SpriteRenderer> ().sprite;
			heldPish.transform.position = transform.position + new Vector3(0f, -2.5f);
			speed = 0;
			if (bopTimer > 0)
				bopTimer -= Time.deltaTime;
			else {
				bopTimer = 0.34f;
				bopping = false;

				heldPish.GetComponent<SpriteRenderer> ().sprite = originalFish;
				heldPish.transform.position = transform.position + new Vector3(1.0f, 0);
			}
		}

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
					if (candle1.GetComponent<Candle> ().lit && candle2.GetComponent<Candle> ().lit && candle3.GetComponent<Candle> ().lit && candle4.GetComponent<Candle> ().lit) 
					{
						candlesLit = true;
					}

					if (!candle1.GetComponent<Candle> ().lit && !candle2.GetComponent<Candle> ().lit && !candle3.GetComponent<Candle> ().lit && !candle4.GetComponent<Candle> ().lit && peopleBopped) 
					{
						candlesUnlit = true;
					}
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


			if (!fishFed) {
				if (foodHome.GetComponent<Overlap> ().overlap) {
					if (holding == false) {
						food.SendMessage ("PickUp");
						holding = true;
					} else {
						food.SendMessage ("PutDown");
						holding = false;
					}
				}

				if (foodSpot.GetComponent<Overlap> ().overlap && food.GetComponent<PoleBehavior> ().held && bookRead) {
					fishFed = true;
					Destroy (food);
					print ("FFFFEEEED THE FEEEEESH");

					//Hide the pish
					pish.GetComponent<SpriteRenderer> ().enabled = false;
					heldPish.GetComponent<PoleBehavior> ().SendMessage ("PickUp");
					heldPish.GetComponent<AudioSource> ().Play ();
				}
			} else if (foodSpot.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held && peopleBopped) 
			{
				heldPish.SendMessage ("PutDown");
				fadeChant = true;
				pish.GetComponent<SpriteRenderer> ().enabled = true;
				holding = true;

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

			if (readPlace.GetComponent<Overlap>().overlap && book.GetComponent<PoleBehavior>().held && candlesLit) 
			{
				waiting = true;
			}

			if (bop1.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held)
			{
				bop1.GetComponent<Overlap> ().bopped = true;
				boppee1.GetComponent<SpriteRenderer> ().sprite = postBop1.GetComponent<SpriteRenderer> ().sprite;
				peopleBopped = checkBop ();
				bopping = true;
			}

			if (bop2.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held)
			{
				bop2.GetComponent<Overlap> ().bopped = true;
				boppee2.GetComponent<SpriteRenderer> ().sprite = postBop2.GetComponent<SpriteRenderer> ().sprite;
				peopleBopped = checkBop ();
				bopping = true;
			}

			if (bop3.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held)
			{
				bop3.GetComponent<Overlap> ().bopped = true;
				boppee3.GetComponent<SpriteRenderer> ().sprite = postBop3.GetComponent<SpriteRenderer> ().sprite;
				peopleBopped = checkBop ();
				bopping = true;
			}

			if (bop4.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held)
			{
				bop4.GetComponent<Overlap> ().bopped = true;
				//peopleBopped = checkBop ();
			}

			if (bop5.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held)
			{
				bop5.GetComponent<Overlap> ().bopped = true;
				boppee5.GetComponent<SpriteRenderer> ().sprite = postBop5.GetComponent<SpriteRenderer> ().sprite;
				peopleBopped = checkBop ();
				bopping = true;
			}

			if (bop6.GetComponent<Overlap> ().overlap && heldPish.GetComponent<PoleBehavior> ().held)
			{
				bop6.GetComponent<Overlap> ().bopped = true;
				boppee6.GetComponent<SpriteRenderer> ().sprite = postBop6.GetComponent<SpriteRenderer> ().sprite;
				peopleBopped = checkBop ();
				bopping = true;
			}

		}



	}

	bool checkBop()
	{
		return (bop1.GetComponent<Overlap> ().bopped && bop2.GetComponent<Overlap> ().bopped && bop3.GetComponent<Overlap> ().bopped && bop5.GetComponent<Overlap> ().bopped && bop6.GetComponent<Overlap> ().bopped);
	}
}
