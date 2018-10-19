using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

	// Update is called once per frame
	void Update()
    {
        // EASY MODE
	    if (Constants.roundTime == 120.0f &&
            Constants.matchAliveTime == 3.5f &&
            Constants.minimumAttackPeriod == 6.0f &&
            Constants.maximumAttackPeriod == 6.0f + Constants.initialCooldownPeriod)
        {
            GameObject.Find("Easy Button").GetComponentInChildren<Text>().text = "Easy ☑";
        }
        else
        {
            GameObject.Find("Easy Button").GetComponentInChildren<Text>().text = "Easy ☐";
        }

        // NORMAL MODE
        if (Constants.roundTime == 240.0f &&
            Constants.matchAliveTime == 5.0f &&
            Constants.minimumAttackPeriod == 4.0f &&
            Constants.maximumAttackPeriod == 4.0f + Constants.initialCooldownPeriod)
        {
            GameObject.Find("Normal Button").GetComponentInChildren<Text>().text = "Normal ☑";
        }
        else
        {
            GameObject.Find("Normal Button").GetComponentInChildren<Text>().text = "Normal ☐";
        }

        // HARD MODE
        if (Constants.roundTime == 360.0f &&
            Constants.matchAliveTime == 6.5f &&
            Constants.minimumAttackPeriod == 2.0f &&
            Constants.maximumAttackPeriod == 2.0f + Constants.initialCooldownPeriod)
        {
            GameObject.Find("Hard Button").GetComponentInChildren<Text>().text = "Hard ☑";
        }
        else
        {
            GameObject.Find("Hard Button").GetComponentInChildren<Text>().text = "Hard ☐";
        }
    }

    public void setSkillEasy()
    {
        GameObject.Find("RoundSlider").GetComponent<Slider>().value = 2;
        GameObject.Find("MatchSlider").GetComponent<Slider>().value = 3.5f;
        GameObject.Find("AttackSlider").GetComponent<Slider>().value = 6.0f;
    }
    public void setSkillNormal()
    {
        GameObject.Find("RoundSlider").GetComponent<Slider>().value = 4;
        GameObject.Find("MatchSlider").GetComponent<Slider>().value = 5.0f;
        GameObject.Find("AttackSlider").GetComponent<Slider>().value = 4.0f;
    }
    public void setSkillHard()
    {
        GameObject.Find("RoundSlider").GetComponent<Slider>().value = 6;
        GameObject.Find("MatchSlider").GetComponent<Slider>().value = 6.5f;
        GameObject.Find("AttackSlider").GetComponent<Slider>().value = 2.0f;
    }
}
