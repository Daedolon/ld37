using UnityEngine;
using System.Collections;

public class AudioSourceDestroyer : MonoBehaviour {

    private AudioSource[] audioSources;

	// Use this for initialization
	void Awake()
    {
        audioSources = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource)
            {
                if (audioSource.isPlaying == false)
                {
                    Destroy(audioSource);
                }
            }
        }
    }

    void LateUpdate()
    {
        Destroy(this);
    }
}
