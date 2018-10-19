using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Variables
    public static CharacterController cc;
    private Vector3 movementDirection = Vector3.zero;
    private Camera cam;

    // Is true if a match is around
    private bool footstep = true;
    public static bool isMatchAlive;
    public static bool running = false;

    private float yaw, pitch;


    private void processAiming()
    {
        if (UserSettings.mouseLocked == true)
        {
            // Get inputs
            // Vertical
            if (UserSettings.invertMouseY == true)
                pitch += Input.GetAxis("Mouse Y") * UserSettings.mouseSensitivity;
            else
                pitch -= Input.GetAxis("Mouse Y") * UserSettings.mouseSensitivity;
            // Horizontal
            yaw = Input.GetAxis("Mouse X") * UserSettings.mouseSensitivity;

            // Apply rotation
            this.transform.Rotate(0.0f, yaw, 0.0f);

            // Clamp angle
            pitch = Mathf.Clamp(pitch, -90, 90);
            // Apply angle
            cam.transform.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);
        }
    }

    IEnumerator checkLastFootStep(float time)
    {
        footstep = false;
        yield return new WaitForSeconds(time);
        footstep = true;
    }

    private void processMovement()
    {
        // Check if we're actually on ground so we can move
        if (cc.isGrounded)
        {
            // Get default inputs
            float strafe = Input.GetAxis("Horizontal");
            float fwd = Input.GetAxis("Vertical");

            // Create new movement vector
            movementDirection = new Vector3(strafe, 0.0f, fwd);

            // Check if player is running
            if (running == true)
                movementDirection *= (Constants.movementSpeed * Constants.runningSpeedModifier);
            else
                movementDirection *= Constants.movementSpeed;

            // Movement vector from local to world
            movementDirection = transform.TransformDirection(movementDirection);

            if (cc.velocity.magnitude > 0.2f && footstep == true)
            {
                PlayerSoundManager.playFootstepSound();
                StartCoroutine(checkLastFootStep(Constants.footstepDelay));
            }

            // Check if the player is jumping
            if (Input.GetButton("Jump"))
            {
                PlayerSoundManager.playFootstepSound();
                movementDirection.y = Constants.jumpingSpeed;
            }
        }

        // Apply the movement
        movementDirection.y -= -Physics.gravity.y * Time.deltaTime;
        cc.Move(movementDirection * Time.deltaTime);
    }


    private void checkRunMode()
    {
        if (Input.GetButton("Run"))
            running = true;
        else
            running = false;
    }


    // When thrown objects leave our vicinity
    // Though if they hit the floor..... FIX!
    void OnTriggerExit(Collider hit)
    {
        hit.isTrigger = false;
    }


    // Throw a match
    void checkUse()
    {
        if (Input.GetButtonDown("Throw Match"))
        {
            // Vector3 firePos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);

            // Create it
            GameObject go = Instantiate(Resources.Load("Prefabs/Match"), cam.transform.position, Quaternion.identity) as GameObject;
            SoundPlayer.playSoundAt(go, "match");
            go.GetComponent<TorchLight>().match = true;
            Collider mc = go.GetComponentInChildren<Collider>();
            mc.isTrigger = true;

            go.transform.SetParent(GameObject.Find("Spawned").transform);

            // Light it
            go.GetComponent<TorchLight>().lit = true;

            // Throw it
            Rigidbody goRb = go.GetComponent<Rigidbody>();
            // Vector3 forwardDirection = this.transform.InverseTransformDirection(cam.transform.forward);
            Vector3 forwardDirection = cam.transform.forward;
            goRb.AddForce(forwardDirection * Constants.playerThrowForce);
        }
    }


    // ??
    void lockCursor()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (UserSettings.mouseLocked == true)
                UserSettings.mouseLocked = false;
            else
                UserSettings.mouseLocked = true;
        }
    }

    void debugMenu()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (UserSettings.debugMode == true)
                UserSettings.debugMode = false;
            else
                UserSettings.debugMode = true;
        }
    }


    // Have player push objects
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        
        if (rb != null && rb.isKinematic == false)
        {
            rb.velocity += hit.controller.velocity / Constants.playerPushForce;
        }
    }


    // Use this for initialization
    void Start()
    {
        cam = this.GetComponentInChildren<Camera>();
        cc = this.GetComponent<CharacterController>();
    }


    // Just see if we still have a match around
    void checkForMatches()
    {
        if (GameObject.Find("Match(Clone)"))
            isMatchAlive = true;
        else
            isMatchAlive = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameInProgress == true && GameStateManager.missionComplete == false && GameStateManager.gameOver == false)
        {
            processAiming();
            checkRunMode();
            processMovement();

            // Only allow us to flick a match if another one isn't in play
            if (isMatchAlive == false)
                checkUse();

            lockCursor();
            debugMenu();

            checkForMatches();
        }

        // please don't do this every frame?
        if (UserSettings.mouseLocked == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
	}
}
