using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class CrosshairCode : MonoBehaviour {

	// Update is called once per frame
	void Update()
    {
	    if (GameStateManager.gameOver == true || UserSettings.mouseLocked == false)
        {
            this.GetComponent<Image>().enabled = false;
        }
        else
        {
            this.GetComponent<Image>().enabled = true;
        }
    }
}
