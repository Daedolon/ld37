using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public static int activeTorches;
    public static bool gameOver = false;
    public static bool missionComplete = false;
    public static float startTime, elapsedTime, timeRemaining, notificationTime;

    // shouldn't do this here lol
    public static bool gameInProgress = false;

    public static bool optionsMenuOpen, helpMenuOpen;


    public void exitGame(bool value)
    {
        if (value == true)
            Application.Quit();
    }

    public void toggleGame(bool value)
    {
        // lol
        gameInProgress = value;

        if (gameInProgress == true)
        {
            UserSettings.mouseLocked = true;
        }
    }

    public void toggleOptions(bool value)
    {
        if (optionsMenuOpen == false)
        {
            optionsMenuOpen = true;
            helpMenuOpen = false;
        }
        else
        {
            optionsMenuOpen = false;
        }
    }

    public void toggleHelp(bool value)
    {
        if (helpMenuOpen == false)
        {
            helpMenuOpen = true;
            optionsMenuOpen = false;
        }
        else
        {
            helpMenuOpen = false;
        }
    }

    // Use this for initialization
    void Start()
    {
        // THIS IS THE PROPER PLACE FOR ALL INITIALIZATIONS
        UserSettings.mouseLocked = false;
        startTime = 0.0f;

        helpMenuOpen = false;
        optionsMenuOpen = false;

        UserSettings.debugMode = false;

        gameInProgress = false;
        gameOver = false;
        missionComplete = false;        // had a bug before since I forgot to reset this here
    }


    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log("Lit torches " + activeTorches);
        Debug.Log("Game status : " + gameInProgress);
        Debug.Log("Game over status : " + gameOver);
        Debug.Log("Mission complete status : " + missionComplete);
        */

        // If we're starting the game for the first time, get starttime
        if (gameInProgress == true && startTime == 0.0f)
        {
            notificationTime = 0.0f;
            GameObject.Find("Briefing").GetComponent<CanvasGroup>().alpha = 1.0f;

            // get this in update
            startTime = Time.time;
        }

        // Fade the notification away
        notificationTime += Time.deltaTime * Constants.notificationDelay;
        GameObject.Find("Briefing").GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1.0f, 0.0f, notificationTime);


        // Game logic stuff
        if (gameInProgress == true)
        {
            // ESC to menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0); /// CHANGE TO 1 BEFORE RELEASE
            }

            // Time stuff
            elapsedTime = Time.time - startTime;
            timeRemaining = Constants.roundTime - elapsedTime;

            if (timeRemaining <= 0.0f && activeTorches > 0)
            {
                missionComplete = true;
                // timeRemaining = 0.0f; // just to make the clock seem fancier (?????)
            }

            // Override game over, shit way to do it but
            if (missionComplete == true)
            {
                gameOver = false;
            }
            if (gameOver == true)
            {
                missionComplete = false;
            }

            if (activeTorches <= 0)
            {
                // Game over?
                gameOver = true;
            }

            if (GameStateManager.missionComplete == true || GameStateManager.gameOver == true)
            {
                if (Input.GetButton("Throw Match") || Input.GetButton("Submit") || Input.GetButton("Cancel"))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
        else
        {
            GameObject.Find("Briefing").GetComponent<CanvasGroup>().alpha = 0.0f;

            if (optionsMenuOpen == true)
            {
                GameObject.Find("Options Menu").GetComponent<CanvasGroup>().alpha = 1.0f;
                GameObject.Find("Options Menu").GetComponent<CanvasGroup>().interactable = true;
                GameObject.Find("Options Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            else
            {
                GameObject.Find("Options Menu").GetComponent<CanvasGroup>().alpha = 0.0f;
                GameObject.Find("Options Menu").GetComponent<CanvasGroup>().interactable = false;
                GameObject.Find("Options Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;
            }

            if (helpMenuOpen == true)
            {
                GameObject.Find("Help Menu").GetComponent<CanvasGroup>().alpha = 1.0f;
                GameObject.Find("Help Menu").GetComponent<CanvasGroup>().interactable = true;
                GameObject.Find("Help Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            else
            {
                GameObject.Find("Help Menu").GetComponent<CanvasGroup>().alpha = 0.0f;
                GameObject.Find("Help Menu").GetComponent<CanvasGroup>().interactable = false;
                GameObject.Find("Help Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }
}
