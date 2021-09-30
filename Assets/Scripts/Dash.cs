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

    private void Start() {
        playerScript = GetComponent<MovePlayer>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            //Sets start and end positions for the dash
            dashStartPosition = transform.position;
            dashEndPosition = new Vector2(dashStartPosition.x + (dashDistance * playerScript.facing), dashStartPosition.y);

            //Checks if the target destination is within a collider, and whether the cat would be within the collider given its own collider.
                //!!!NOTE!!! This will need to be updated if the cat models are updated and moved away from circle colliders!!! It will break otherwise!!!
			if (!Physics2D.OverlapBox(dashEndPosition, new Vector2(GetComponent<CircleCollider2D>().bounds.extents.x * 2, GetComponent<CircleCollider2D>().bounds.extents.y), 0)) {
                StartCoroutine(DashCoroutine());
            }
        }
    }

    IEnumerator DashCoroutine()
    {
        anim.SetTrigger("Dash");
        anim.SetBool("isWalking", false);
        // Wait for animation to finish
        yield return new WaitForSeconds(dashChargeTime);
        transform.position = dashEndPosition;
    }
}
