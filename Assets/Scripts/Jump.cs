using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float jumpForce;
    private bool jumpInput;
    private bool isJumping;
    private float gravity;
    public MovePlayer playerScript;
	public AudioController audioController;
    private Vector2 colliderBounds;

    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
		colliderBounds = GetComponent<BoxCollider2D>().bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        gravity = GetComponent<Rigidbody2D>().gravityScale;

        jumpInput = Input.GetKeyDown("space") | Input.GetKeyDown("w") | Input.GetKeyDown("up");
        if (jumpInput && !playerScript.frozen) {
			RaycastHit2D rayMiddle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(0, -1 * gravity), 0.5f, ~(Physics2D.IgnoreRaycastLayer));
			RaycastHit2D rayRight = Physics2D.Raycast(new Vector2(transform.position.x + colliderBounds.x, transform.position.y), new Vector2(0, -1 * gravity), 0.5f, ~(Physics2D.IgnoreRaycastLayer));
			RaycastHit2D rayLeft = Physics2D.Raycast(new Vector2(transform.position.x - colliderBounds.x, transform.position.y), new Vector2(0, -1 * gravity), 0.5f, ~(Physics2D.IgnoreRaycastLayer));
            
            if ((rayLeft.collider || rayMiddle.collider || rayRight.collider) && !isJumping){
				audioController.PlayAudioClip(audioController.audioClips[1]);
				isJumping = true;
				anim.SetTrigger("Jump");
				anim.SetBool("isWalking", false);

				rb.AddForce(new Vector2(0, jumpForce * gravity), ForceMode2D.Impulse);
            }
        }
		if (!jumpInput) {
			isJumping = false;
		}
	}
}
