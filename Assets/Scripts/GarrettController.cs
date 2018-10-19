using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class GarrettController : MonoBehaviour {

    private bool planningAttack;
    private bool attacking;
    public static List<GameObject> activeTorches;
    private GameObject targetTorch;


    // Find all active torches
    void getActiveTorches()
    {
        activeTorches = new List<GameObject>();

        foreach (GameObject torch in GameObject.FindGameObjectsWithTag("Torch"))
        {
            if (torch.GetComponent<TorchLight>().lit == true)
                activeTorches.Add(torch);
        }

        GameStateManager.activeTorches = activeTorches.Count;
    }


    int randomTorchIndex(int numTorches)
    {
        return Random.Range(0, numTorches - 1);
    }


    // Destroy match after n seconds
    IEnumerator douseRandomTorch(float time)
    {
        attacking = true;

        // Pick target torch
        targetTorch = activeTorches[randomTorchIndex(GameStateManager.activeTorches)];

        // Wait for seconds
        yield return new WaitForSeconds(time);

        // Just to be VERY explicit
        if (GameStateManager.missionComplete == false && GameStateManager.gameOver == false)
        {
            // Douse torch / play sound
            targetTorch.GetComponent<TorchLight>().lit = false;
            SoundPlayer.playSoundAt(targetTorch, "douse");
        }

        // Set us to hide in the shadows
        attacking = false;
        planningAttack = true;
    }


    IEnumerator waitPlayerOrientatePeriod(float time)
    {
        yield return new WaitForSeconds(time);
        planningAttack = true;
    }


    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitPlayerOrientatePeriod(Constants.initialCooldownPeriod));

        // THIS WILL BREAK TIME ATTACK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        GameStateManager.activeTorches = 1; // TEMP HAX FIX, FIX LATER
    }
	

	// Update is called once per frame
	void Update()
    {
        if (GameStateManager.gameInProgress == true)
        {
            getActiveTorches();

            if (GameStateManager.missionComplete == false && GameStateManager.gameOver == false)
            {
                if (planningAttack == true && attacking == false && activeTorches.Count > 0)
                {
                    float randomTime = Random.Range(Constants.minimumAttackPeriod, Constants.maximumAttackPeriod);
                    StartCoroutine(douseRandomTorch(randomTime));
                }
            }
        }
       
    }
}
