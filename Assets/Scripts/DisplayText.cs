using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayText : MonoBehaviour {

    public float letterPause = 0.03f;
    string messageText;
    string text;
    Color textColor;


	// Use this for initialization
    void Start()
    {
        //this.SendMessage("updateText", "blah blah blah");
    }

    void setRate(int rate)
    {
        letterPause = (float)rate * 0.01f;
    }

    void setColor(string color)
    {
        List<float> components = new List<float>();
        foreach (string c in color.Split(','))
        {
            float c_float;
            float.TryParse(c, out c_float);
            components.Add(c_float);
        }
        textColor = new Color(components[0], components[1], components[2], 1.0f);
        GetComponent<Text>().color = textColor;
    }

    void updateText(string message)
    {
        
        messageText = message;
        text = "";
        StartCoroutine(TypeText()); 
    }

    IEnumerator TypeText()
    {
        foreach (char letter in messageText.ToCharArray())
        {
            text += letter;
            GetComponent<Text>().text = text;
            //if (sound)
            //    audio.PlayOneShot(sound);
            yield return new WaitForSeconds(letterPause);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
