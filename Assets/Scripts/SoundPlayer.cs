using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {

    private static void destroyExistingAudioSources(GameObject go)
    {
        AudioSource[] existingAudioSources = go.GetComponents<AudioSource>();
        if (existingAudioSources.Length > 0)
        {
            foreach (AudioSource ex in existingAudioSources)
            {
                if (ex.isPlaying == false)
                    Destroy(ex);
            }
        }
        existingAudioSources = null;
    }

    public static void playSoundAt(GameObject go, string sound)
    {
        int fileNumber = 1;
        string fileName = "";
        float volume = 1.0f;

        switch (sound)
        {
            case "match":
                fileNumber = Random.Range(1, 4);
                fileName = "match_throw" + fileNumber;
                volume = 0.8f;
                break;
            case "douse":
                fileNumber = Random.Range(1, 4);
                fileName = "douse" + fileNumber;
                break;
            case "Bottle":
                fileNumber = Random.Range(1, 4);
                fileName = "bottle" + fileNumber;
                volume = 0.4f;
                break;
            case "Book":
                fileNumber = Random.Range(1, 4);
                fileName = "kirja" + fileNumber;
                volume = 0.7f;
                break;
            case "Crate":
                fileNumber = Random.Range(1, 4);
                fileName = "box" + fileNumber;
                volume = 0.5f;
                break;
            case "Stool":
                fileNumber = Random.Range(1, 4);
                fileName = "chair" + fileNumber;
                volume = 0.25f;
                break;
            case "Torch":
                fileNumber = Random.Range(1, 4);
                fileName = "kirja" + fileNumber;
                break;
        }

        // Generate audio source
        destroyExistingAudioSources(go);

        AudioSource audioSource = go.AddComponent<AudioSource>() as AudioSource;

        // Play the sound
        audioSource.clip = Resources.Load("Audio/" + fileName) as AudioClip;
        audioSource.volume = volume;
        audioSource.spatialBlend = 1.0f;
        audioSource.Play();

        // Destroy audiosource afterwards
        go.AddComponent<AudioSourceDestroyer>();
    }
}
