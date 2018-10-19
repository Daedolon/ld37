using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class FillTime : MonoBehaviour {

    private Image image;

    void Start()
    {
        image = GetComponentInChildren<Image>();
    }


    // Update is called once per frame
    void Update()
    {
	    if (PlayerController.isMatchAlive)
        {
            image.enabled = true;
            image.fillAmount -= 1.0f / Constants.matchAliveTime * Time.deltaTime;
        }
        else
        {
            image.enabled = false;
            image.fillAmount = 1.0f;
        }
    }
}
