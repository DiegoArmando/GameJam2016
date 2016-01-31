using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class Priest : MonoBehaviour {
    public GameObject TextBox;
    private bool interrupted = false;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        StartCoroutine(PriestScript());
		//print(gameObject.GetComponent<HideThese> ().hideMe [2].ToString ());
	}

    WaitForSeconds ParseLine(string line)
    {
        float waitTime = 0f;

        if (line.Substring(0, 1) == "<")
        {
            switch (line.Substring(1, 4))
            {
                case "wait":
                    int seconds;
                    int.TryParse(line.Substring(6, line.Length - 7), out seconds);
                    waitTime = seconds;
                    break;

                case "rate":
                    int rate;
                    int.TryParse(line.Substring(6, line.Length - 7), out rate);
                    TextBox.SendMessage("setRate", rate);
                    break;

                case "colr":
                    string colornum = line.Substring(6, line.Length - 7);
                    TextBox.SendMessage("setColor", colornum);
                    break;
            }
        }
        else
        {
            TextBox.SendMessage("updateText", line);
        }

        return new WaitForSeconds(waitTime);
    }

    public System.Collections.Generic.Dictionary<string, int> interruptions = new System.Collections.Generic.Dictionary<string, int>();

    void Interrupt(string phase)
    {
        if (phase == "staff2")
        {
            phase = "staff";
            interruptions["staff"] = 0;
        }
        if (interruptions.ContainsKey(phase))
        {
            interruptions[phase]++;
        }
        else
        {
            interruptions[phase] = 1;
        }
        if (interruptions[phase] > 3) interruptions[phase] = 3;
		print ("boop");
		print ("What we are sending: " + phase + interruptions [phase] + ".txt");
		StartCoroutine(InterruptScript(phase + interruptions[phase] + ".txt"));
		print ("post boopism");
    }

    IEnumerator InterruptScript(string scriptFile)
    {
		print ("Does streamreader brok everythinangds?");
        StreamReader reader = new StreamReader("assets\\" + scriptFile, Encoding.Default);
		print ("inside interrupt with script " + scriptFile);
        string line = "";
		if (!interrupted)
		{
			interrupted = true;
			do
			{
				line = reader.ReadLine ();
				if (line != null)
				{
					yield return ParseLine (line);
				}
				yield return 0;
			} while (line != null);
			interrupted = false;
			timer = 7f;
		}
    }

    IEnumerator PriestScript()
    {
        StreamReader reader = new StreamReader("assets\\priest.txt", Encoding.Default);
        string line = "";
        do
        {
            if (!interrupted)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    yield return ParseLine(line);
                }
			}
			yield return 0;
        } while (line != null);
    }

    public float timer = 7f;
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 7f;
            if (!Player.GetComponent<Move>().candlesLit)
            {
                if (!Player.GetComponent<Move>().pole.GetComponent<PoleBehavior>().held)
                {
                    Interrupt("staff");
                }
                else
                {
                    Interrupt("light");
                }
            }
            else //candles are lit
            {
                if (!Player.GetComponent<Move>().bookRead)
                {
                    if (!Player.GetComponent<Move>().book.GetComponent<PoleBehavior>().held)
                    {
                        Interrupt("book");
                    }
                    else
                    {
                        Interrupt("read");
                    }
                }
                else //book is read
                {
                    if (!Player.GetComponent<Move>().fishFed)
                    {
                        if (!Player.GetComponent<Move>().food.GetComponent<PoleBehavior>().held)
                        {
                            Interrupt("food");
                        }
                        else
                        {
                            Interrupt("feed");
                        }
                    }
                    else //fish is fed
                    {
                        if (!Player.GetComponent<Move>().peopleBopped)
                        {
                            Interrupt("bop");
                        }
                        else //people are bopped
                        {
                            if (Player.GetComponent<Move>().heldPish.GetComponent<PoleBehavior>().held)
                            {
                                Interrupt("pool");
                            }
                            else //fish is returned
                            {
                                if (!Player.GetComponent<Move>().candlesUnlit)
                                {
                                    if (!Player.GetComponent<Move>().pole.GetComponent<PoleBehavior>().held)
                                    {
                                        Interrupt("staff2");
                                    }
                                    else
                                    {
                                        Interrupt("snuff");
                                    }
                                }
                                else //candles are snuffed
                                {
                                    //win state
                                }
                            }
                        }
                    }
                }
            }
        }
	}
}
