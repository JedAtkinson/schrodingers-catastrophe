using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Vector2 dashStartPosition;
    private Vector2 dashEndPosition;
    private MovePlayer playerScript;
    public float dashDistance;

    public float dashChargeTime;
    public Animator anim;
    public bool swapFrozen;
    public AudioController audioController;

    private void Start() {
        swapFrozen = false;
        playerScript = GetComponent<MovePlayer>();
    }
    private void Update() {
        if (!swapFrozen) {
			if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
			{
				Vector2 colliderBounds = GetComponent<BoxCollider2D>().bounds.extents;

				//Sets start and end positions for the dash
				dashStartPosition = transform.position;
				dashEndPosition = new Vector2(dashStartPosition.x + (dashDistance * playerScript.facing), dashStartPosition.y);

				//Checks if the target destination passes through a door and returns if it does
				RaycastHit2D doorHit = Physics2D.Raycast(transform.position, Vector2.right * playerScript.facing, dashDistance + colliderBounds.x, LayerMask.GetMask("Door"));
				if (doorHit)
				{
					return;
				}
				//Checks if the target destination is clear of any obstacles and begins dash sequence if it is
				if (!Physics2D.OverlapBox(dashEndPosition, new Vector2(colliderBounds.x, colliderBounds.y), 0))
				{
					StartCoroutine(DashCoroutine());
				}
			}
        }
    }

    IEnumerator DashCoroutine()
    {
        audioController.PlayAudioClip(audioController.audioClips[0]);
        playerScript.frozen = swapFrozen = true;
        anim.SetTrigger("Dash");
        anim.SetBool("isWalking", false);
        // Wait for animation to finish
        yield return new WaitForSeconds(dashChargeTime);
        transform.position = dashEndPosition;
		playerScript.frozen = swapFrozen = false;
    }
}
