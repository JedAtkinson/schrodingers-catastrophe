using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    public void PlayAudioClip(AudioClip clip){
        audioSource.PlayOneShot(clip, 0.5f);
    }
}
