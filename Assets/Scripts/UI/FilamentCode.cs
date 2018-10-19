using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

public class FilamentCode : MonoBehaviour {

    private Renderer renderer;
    private List<GameObject> torches;

    // Colors
    // private Color32 defaultColor;
    private Color32 averageColor;
    private float r, g, b, a;

    private int numTorchesLit;

    private float valueOfTorch;


    void Start()
    {
        // torches = new List<GameObject>();
        torches = GameObject.FindGameObjectsWithTag("Torch").ToList();
        renderer = this.GetComponent<Renderer>();
        // defaultColor = renderer.material.color;
    }


	// Update is called once per frame
	void Update()
    {
        numTorchesLit = 0;

        foreach (GameObject torch in torches)
        {
            if (torch.GetComponent<TorchLight>().lit == true)
                numTorchesLit++;
        }

        // Value of a single torch, out of 255
        valueOfTorch = 255 / torches.Count();
        // valueOfTorch = 255 / (torches.Count() + 2) + (2 * (255 / torches.Count()));
        averageColor = new Color32((byte)(numTorchesLit * valueOfTorch), (byte)(numTorchesLit * valueOfTorch), (byte)(numTorchesLit * valueOfTorch), 0);

        renderer.material.color = Color.Lerp(renderer.material.color, averageColor, Mathf.PingPong(Time.time, 0.1f));
        // renderer.material.color = averageColor;
    }
}
