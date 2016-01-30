using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

    public float letterPause = 0.03f;
    string messageText;
    string text;

	// Use this for initialization
    void Start()
    {
        this.SendMessage("updateText", "blah blah blah");
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
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
