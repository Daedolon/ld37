using UnityEngine;
using System.Collections;

public class MenuStatusThing : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameInProgress == true)
        {
            // HUD
            GameObject.Find("UI Stuff").GetComponent<CanvasGroup>().alpha = 1.0f;

            // Main Menu
            GameObject.Find("Main Menu").GetComponent<CanvasGroup>().alpha = 0.0f;
            GameObject.Find("Main Menu").GetComponent<CanvasGroup>().interactable = false;

        }
        else
        {
            // HUD
            GameObject.Find("UI Stuff").GetComponent<CanvasGroup>().alpha = 0.0f;

            // Main menu
            GameObject.Find("Main Menu").GetComponent<CanvasGroup>().alpha = 1.0f;
            GameObject.Find("Main Menu").GetComponent<CanvasGroup>().interactable = true;
        }
    }
}
