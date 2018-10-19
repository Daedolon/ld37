using UnityEngine;
using System.Collections;

public class PlayerSoundManager : MonoBehaviour {

    public static AudioSource[] audioSources;

	// Use this for initialization
	void Start()
    {
        // Get audiosources
        // 1 = matches
        // 2 = footsteps
        audioSources = GetComponents<AudioSource>();

        audioSources[0].spatialBlend = 1.0f;
        audioSources[1].spatialBlend = 1.0f;
    }

    public static void playMatchSound()
    {
        int fileNumber = Random.Range(1, 4);
        string fileName = "match_throw" + fileNumber;

        // audioSources[0].Stop();
        audioSources[0].clip = Resources.Load("Audio/" + fileName) as AudioClip;
        audioSources[0].Play();
    }
    public static void playFootstepSound()
    {
        int fileNumber = Random.Range(1, 8);
        string fileName = "step" + fileNumber;

        if (PlayerController.running == true)
            audioSources[1].volume = 0.75f;
        else
            audioSources[1].volume = 0.35f;

        // audioSources[1].Stop();
        audioSources[1].clip = Resources.Load("Audio/" + fileName) as AudioClip;
        audioSources[1].Play();
    }

    void Update()
    {
        if (GameStateManager.gameInProgress)
        {
            if (audioSources[2].isPlaying == false)
                audioSources[2].Play();
        }
        else
        {
            if (audioSources[2].isPlaying == true)
                audioSources[2].Stop();
        }
    }
}
