using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Constants {

    // Player movement
    public static float movementSpeed = 4.5f; // 5.5f
    public static float runningSpeedModifier = 1.35f; // 1.5f
    public static float jumpingSpeed = 4.25f; // 4.0f

    // Physics
    public static float playerThrowForce = 350.0f; // 12.0f;
    public static float playerPushForce = 4.0f;

    // Inventory item
    public static float spinSpeed = 66.6f;

    // Camera drives
    // public static float cameraDriveSpeed = 7.5f;
    public static float cameraDriveSpeed = 0.1f;

    public static float audioHitVelocity = 1.5f;
    public static float footstepDelay = 0.4f;

    public static float notificationDelay = 0.25f;

    // SKILL LEVEL STUFF

    // EASY

    // Game round
    // public static float roundTime = 120.0f;             // 2 minutes
    public static float roundTime = 120.0f;             // 2 minutes

    // Taffer
    public static float matchAliveTime = 3.5f;          // How fast the player can flick another match

    // Garrett
    public static float minimumAttackPeriod = 6.0f;     // How fast the enemy douses torches
    public static float maximumAttackPeriod = 11.0f;     // 10.0f --- but now it's 4x miminumperiod
    public static float initialCooldownPeriod = 5.0f;
}
