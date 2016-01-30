using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float speed;
	public bool running = false;
	public GameObject pole;
	public GameObject poleHome;
	public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
		}

		if (Input.GetKey (KeyCode.D)) {
			this.gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W)) {
			this.gameObject.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			this.gameObject.transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{

			if (poleHome.GetComponent<Overlap>().overlap)
			{
				if (pole.GetComponent<PoleBehavior> ().held)
				{
					print ("We should be putting down the pole now");
					pole.SendMessage ("PutDown");
				}
				else
				{
					pole.SendMessage ("PickUp");
				}
			}






		}



	}
}
