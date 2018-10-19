using UnityEngine;
using System.Collections;

public class MenusHopefully : MonoBehaviour {

    // Find player start locations

    // Find camera stuff too


	// Use this for initialization
	void Start()
    {
        if (GameStateManager.gameInProgress == false)
        {

        }
    }
	
    
    // Please use a separate scene, or?
    // This will break 100%
    void drawMainMenu()
    {
        if (GameStateManager.gameInProgress == false)
        {

        }
        else
        {

        }
    }


    // Update is called once per frame
    void Update()
    {
        drawMainMenu();

        if (GameStateManager.gameInProgress == false)
        {
        }
    }
}
