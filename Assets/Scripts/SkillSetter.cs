using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class SkillSetter : MonoBehaviour {

    public Slider roundTimeSlider;
    public void roundTime()
    {
        GetComponentInChildren<Text>().text = "ROUND LENGTH (" + roundTimeSlider.value + " minutes)";
        Constants.roundTime = roundTimeSlider.value * 60;
    }
    public Slider matchDelaySlider;
    public void matchDelay()
    {
        GetComponentInChildren<Text>().text = "MATCH DELAY (" + matchDelaySlider.value.ToString("0.0") + " seconds)";
        Constants.matchAliveTime = matchDelaySlider.value;
    }
    public Slider attackDelaySlider;
    public void attackDelay()
    {
        GetComponentInChildren<Text>().text = "ATTACK DELAY (" + attackDelaySlider.value.ToString("0.0") + " seconds)";
        Constants.minimumAttackPeriod = attackDelaySlider.value;
        Constants.maximumAttackPeriod = attackDelaySlider.value + Constants.initialCooldownPeriod;
    }
}
