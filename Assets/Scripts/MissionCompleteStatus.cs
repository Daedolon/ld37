﻿using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class MissionCompleteStatus : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.missionComplete == true)
        {
            this.GetComponentInChildren<Image>().enabled = true;
            this.GetComponentInChildren<Text>().enabled = true;
        }
        else
        {
            this.GetComponentInChildren<Image>().enabled = false;
            this.GetComponentInChildren<Text>().enabled = false;
        }
    }
}
