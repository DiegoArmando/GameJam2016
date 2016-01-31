using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class Priest : MonoBehaviour {
    public GameObject TextBox;
    private bool interrupted = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(PriestScript());
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

    IEnumerator InterruptScript(string scriptFile)
    {
        StreamReader reader = new StreamReader("assets\\" + scriptFile, Encoding.Default);
        string line = "";
        interrupted = true;
        do
        {
            if (!interrupted)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    yield return ParseLine(line);
                }
                yield return 0;
            }
        } while (line != null);
        interrupted = false;
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
                yield return 0;
            }
        } while (line != null);
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
