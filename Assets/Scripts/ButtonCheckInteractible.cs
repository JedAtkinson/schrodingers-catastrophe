using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheckInteractible : MonoBehaviour
{
    private Animator animator;
    public GameObject door;
    public AudioController audioController;
    private void Start() {
        animator = GetComponent<Animator>();
        audioController = FindObjectOfType<AudioController>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "interactable")
        {
            animator.SetBool("pushed", true);
            door.SetActive(!door.activeSelf);
            audioController.PlayAudioClip(audioController.audioClips[2]);
            //Button push function for interactibles here: opening door, activating mechanism, etc.
            //Can recode to handle button pushes in the interactible script (will make this script constant), but this works for now
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "interactable")
        {
            animator.SetBool("pushed", false);
            door.SetActive(!door.activeSelf);
            audioController.PlayAudioClip(audioController.audioClips[3]);
        }
    }
}
