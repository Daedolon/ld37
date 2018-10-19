using UnityEngine;
using System.Collections;

public class ItemSpin : MonoBehaviour {

    // add "new" to fix later
    private Renderer renderer;
    private static Vector3 startPos;

    void Start()
    {
        renderer = this.GetComponentInChildren<Renderer>();
        startPos = this.transform.position;
    }

	// Update is called once per frame
	void Update()
    {
        // Use collider bounds
        Vector3 center = renderer.bounds.center;

        /// Debug.Log(center);

        // Obsolete
        // this.transform.RotateAround(Vector3.up, Constants.spinSpeed * Time.deltaTime);
        this.transform.RotateAround(center, Vector3.up, Constants.spinSpeed * Time.deltaTime);

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, startPos.z);
	}
}
