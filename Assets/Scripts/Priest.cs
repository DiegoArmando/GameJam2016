using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class Priest : MonoBehaviour {
    public GameObject TextBox;
	// Use this for initialization
	void Start () {
        StartCoroutine(PriestScript());
	}

    IEnumerator PriestScript()
    {
        //TextBox.SendMessage("updateText", "Here's what I'm saying at the beginning.");
        //yield return new WaitForSeconds(5);
        //TextBox.SendMessage("updateText", "Line Two");
        StreamReader reader = new StreamReader("assets\\priest.txt", Encoding.Default);
        string line;
        do
        {
            line = reader.ReadLine();
            if (line != null)
            {
                if (line.Substring(0,1) == "<")
                {
                    switch (line.Substring(1, 4))
                    {
                        case "wait":
                            int seconds;
                            int.TryParse(line.Substring(6, line.Length - 7), out seconds);
                            yield return new WaitForSeconds(seconds);
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
            }
            yield return 0;
        } while (line != null);
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
