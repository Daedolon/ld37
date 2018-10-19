using UnityEngine;
using System.Collections;

public class MakeNoise : MonoBehaviour {

    void OnCollisionEnter(Collision hit)
    {
        if (hit.relativeVelocity.magnitude > Constants.audioHitVelocity)
        {
            SoundPlayer.playSoundAt(gameObject, this.transform.name);
        }
    }
}
