using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    private Animator animator;
    public GameObject door;
    private void Start() {
        animator = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        //Checks whether the 'cat' that pushed the button is the live cat
		if (collision.gameObject.tag == "Live_Cat")
		{
			animator.SetBool("pushed", true);
            collision.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            door.SetActive(false);
            //Button push function for interactibles here: opening door, activating mechanism, etc.
                //Can recode to handle button pushes in the interactible script (will make this script constant), but this works for now
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        animator.SetBool("pushed", false);
        collision.attachedRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        door.SetActive(true);
    }
}
