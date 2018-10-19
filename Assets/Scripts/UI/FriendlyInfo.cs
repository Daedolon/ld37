using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class FriendlyInfo : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        if (GameStateManager.gameInProgress == true && UserSettings.mouseLocked == false)
        {
            this.GetComponentInChildren<Text>().enabled = true;
        }
        else
        {
            this.GetComponentInChildren<Text>().enabled = false;
        }
    }
}
