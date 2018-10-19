using UnityEngine;
using System.Collections;

public class MenuCameraScript : MonoBehaviour {

    private bool cameraDrive = false;
    private int ajonumero = 0, previousAjonumero = 0;
    private Vector3 startPos = Vector3.zero, endPos = Vector3.zero, driveAngle;
    private GameObject menuCamera;
    private static Vector3 menuCameraPosition;
    private static Vector3 menuCameraRotation;  

    float lerpStuff;

    // Use this for initialization
    void Start()
    {
        menuCamera = GameObject.Find("Menu Camera");

        menuCameraPosition = new Vector3(-1.011f, 6.655f, -20.872f);
        menuCameraRotation = new Vector3(0.0f, 32.0f, 0.0f);

        menuCamera.transform.position = menuCameraPosition;
        menuCamera.transform.eulerAngles = menuCameraRotation;
    }
	
	// Update is called once per frame
	void Update()
    {
        if (GameStateManager.gameInProgress == false)
        {
            // Debug.Log("Camera drive " + cameraDrive);
            // Debug.Log("Camera numero " + ajonumero);

            if (cameraDrive == true)
            {
                if (menuCamera.transform.position != endPos)
                {
                    // menuCamera.transform.position = Vector3.Lerp(startPos, endPos, Time.time / Constants.cameraDriveSpeed);
                    // menuCamera.transform.position = Vector3.Lerp(startPos, endPos, Time.deltaTime * Constants.cameraDriveSpeed);
                    lerpStuff += Time.deltaTime * Constants.cameraDriveSpeed;
                    menuCamera.transform.position = Vector3.Lerp(startPos, endPos, lerpStuff);
                }
                else
                {
                    cameraDrive = false;
                }
            }
            else
            {
                // Find the next drive
                do
                {
                    ajonumero = Random.Range(0, 3);
                } while (ajonumero == previousAjonumero);

                previousAjonumero = ajonumero;

                switch (ajonumero)
                {
                    case 0:
                        startPos = new Vector3(-0.781f, 6.655f, -23.246f);
                        endPos = new Vector3(-0.781f, 6.655f, -13.329f);
                        driveAngle = new Vector3(0.0f, 32.0f, 0.0f);
                        break;
                    case 1:
                        startPos = new Vector3(-1.374f, 1.67f, -23.31f);
                        endPos = new Vector3(-1.374f, 1.67f, -14.56f);
                        driveAngle = new Vector3(0.0f, -47.011f, 0.0f);
                        break;
                    case 2:
                        startPos = new Vector3(-7.717f, 6.2f, -14.42f);
                        endPos = new Vector3(-0.67f, 6.2f, -14.42f);
                        driveAngle = new Vector3(0.0f, 123.296f, 0.0f);
                        break;
                    case 3:
                        startPos = new Vector3(4.633f, 2.323f, -26.54f);
                        endPos = new Vector3(-3.45f, 2.323f, -26.54f);
                        driveAngle = new Vector3(0.0f, -48.567f, 0.0f);
                        break;
                }
                menuCamera.transform.position = startPos;
                menuCamera.transform.eulerAngles = driveAngle;
                cameraDrive = true;
                lerpStuff = 0.0f;
            }
        }

        if (GameStateManager.gameInProgress == false)
        {
            // Menu Camera
            GameObject.Find("Menu Camera").GetComponent<Camera>().enabled = true;
            GameObject.Find("Menu Camera").GetComponent<FlareLayer>().enabled = true;
            GameObject.Find("Menu Camera").GetComponent<GUILayer>().enabled = true;
            GameObject.Find("Menu Camera").GetComponent<AudioListener>().enabled = true;

            // FPS camera
            GameObject.Find("Player Camera").GetComponent<Camera>().enabled = false;
            GameObject.Find("Player Camera").GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            // Menu Camera
            GameObject.Find("Menu Camera").GetComponent<Camera>().enabled = false;
            GameObject.Find("Menu Camera").GetComponent<FlareLayer>().enabled = false;
            GameObject.Find("Menu Camera").GetComponent<GUILayer>().enabled = false;
            GameObject.Find("Menu Camera").GetComponent<AudioListener>().enabled = false;

            // FPS camera
            GameObject.Find("Player Camera").GetComponent<Camera>().enabled = true;
            GameObject.Find("Player Camera").GetComponent<AudioListener>().enabled = true;
        }
    }
}
