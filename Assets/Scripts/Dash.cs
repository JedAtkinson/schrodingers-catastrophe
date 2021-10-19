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
    private Vector2 colliderBounds;

    private void Start() {
        swapFrozen = false;
        playerScript = GetComponent<MovePlayer>();
        audioController = FindObjectOfType<AudioController>();
		colliderBounds = GetComponent<BoxCollider2D>().bounds.extents;
    }
    private void Update() {
        if (!swapFrozen) {
			if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
			{
				//Sets start and end positions for the dash
				dashStartPosition = transform.position;
				dashEndPosition = new Vector2(dashStartPosition.x + (dashDistance * playerScript.facing), dashStartPosition.y);

				//Checks if the target destination passes through an impassable obstacle (e.g. a door) and returns if it does
				RaycastHit2D impassableHit = Physics2D.Raycast(transform.position, Vector2.right * playerScript.facing, dashDistance + colliderBounds.x, LayerMask.GetMask("Impassable"));
				if (impassableHit)
				{
					return;
				}
				//Checks if the target destination is clear of any obstacles and begins dash sequence if it is
                Debug.Log(Physics2D.OverlapBox(dashEndPosition, colliderBounds * 2, 0));
				if (!Physics2D.OverlapBox(dashEndPosition, new Vector2(colliderBounds.x * 2, colliderBounds.y * 1.95f), 0))
				{
					StartCoroutine(DashCoroutine());
				}
			}
        }
    }

    //Uncomment this method to see the dash end position, you'll notice that it will allow you to dash if it isn't *intersecting* and colliders
    /* void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(dashEndPosition, new Vector3(colliderBounds.x * 2, colliderBounds.y * 2, 1));
    } */

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
