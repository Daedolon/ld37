using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class DebugInfo : MonoBehaviour {

	// Update is called once per frame
	void Update()
    {
        if (UserSettings.debugMode == false)
        {
            this.GetComponentInChildren<Text>().enabled = false;
        }
        else
        {
            this.GetComponentInChildren<Text>().enabled = true;

            GetComponentInChildren<Text>().text = "Time remaining : " + (Constants.roundTime - GameStateManager.elapsedTime + "\n" +
                "Lit torches : " + GameStateManager.activeTorches);
        }
	}
}
