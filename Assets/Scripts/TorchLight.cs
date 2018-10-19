using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class TorchLight : MonoBehaviour {

    // Status
    public bool lit;
    public bool match;

    // Particles
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule em;
    private ParticleSystem.Particle[] particles;
    private int numParticles;

    // Colors
    private List<Color32> allColors;
    private Color32 averageColor;
    private float r, g, b, a;

    // Light
    private Light light;


    // Destroy match after n seconds
    IEnumerator douseMatch(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }


	// Use this for initialization
	void Start ()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        em = ps.emission;
        particles = new ParticleSystem.Particle[128];
        light = GetComponentInChildren<Light>();
	}


    void OnCollisionEnter(Collision hit)
    {
        if (lit == false)
        {
            string name = hit.collider.transform.parent.gameObject.name;

            if (name == "Torch" || name == "Torch(Clone)" ||
                name == "Match" || name == "Match(Clone)")
            {
                this.lit = true;
            }
        }
    }


    void OnParticleCollision(GameObject go)
    {
        // do this later if you want to be fancy
    }


    void LateUpdate()
    {
        light.color = averageColor;
        // light.color = Color.Lerp(Color.red, Color.yellow, (Mathf.PingPong(Time.deltaTime, 0.1f) / 0.1f));
    }


	// Update is called once per frame
	void Update()
    {
        // If we're a match thrown by the player
        if (match == true)
        {
            // Start countdown
            StartCoroutine(douseMatch(Constants.matchAliveTime));
            match = false;
        }


        // lit?
        if (lit == true)
            em.enabled = true;
        else
            em.enabled = false;


        numParticles = ps.GetParticles(particles);
        allColors = new List<Color32>();

        for (int i = 0; i < numParticles; i++)
        {
            // wtf?
            allColors.Add(particles[i].GetCurrentColor(ps));
        }

        r = light.color.r;
        g = light.color.g;
        b = light.color.b;

        foreach (Color32 color in allColors)
        {
            r += color.r;
            g += color.g;
            b += color.b;
        }

        averageColor = new Color32((byte)(r / allColors.Count), (byte)(g / allColors.Count), (byte)(b / allColors.Count), 0);


        dimLightwithParticles();
    }


    // Does this even work? fucken 5:51 am
    void dimLightwithParticles()
    {
        float intensity = 0;

        // fewer particles --> Light.Intensity from 1 to 0 plz
        if (ps.particleCount != 0)
            intensity = 128 / ps.particleCount; // intensity value of a single particle

        if (intensity != 0)
            intensity = intensity / intensity;

        light.intensity = intensity;
    }
}
