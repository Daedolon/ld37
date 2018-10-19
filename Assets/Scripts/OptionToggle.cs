using UnityEngine;
using System.Collections;

public class OptionToggle : MonoBehaviour {

    public void toggleInvertedMouse()
    {
        if (UserSettings.invertMouseY == true)
            UserSettings.invertMouseY = false;
        else
            UserSettings.invertMouseY = true;
    }

}
