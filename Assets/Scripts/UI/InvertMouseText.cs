using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class InvertMouseText : MonoBehaviour {

	// Update is called once per frame
	void Update()
    {
        if (UserSettings.invertMouseY == true)
            this.GetComponent<Text>().text = "Invert Mouse ☑";
        else
            this.GetComponent<Text>().text = "Invert Mouse ☐";
    }
}
