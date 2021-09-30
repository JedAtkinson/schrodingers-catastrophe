using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float direction;
    public Rigidbody2D rb;
    public float playerSpeed;
    public GameObject opposite;
    public GameObject screen;
    private Vector3 opp_pos;
    public int facing;

    public Animator anim;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            facing = 1;
            sr.flipX = false;
        }
        else if (direction < 0)
        {
            facing = -1;
            sr.flipX = true;
        }
        rb.velocity = new Vector2(direction * playerSpeed, rb.velocity.y);

        // Walking animation
        if (direction != 0) anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);

        if (Input.GetKeyDown(KeyCode.R))
        {
			rb.isKinematic = true;
            opp_pos = opposite.transform.position;
            opposite.transform.position = this.transform.position;
            this.transform.position = opp_pos;
            rb.isKinematic = false;
            rb.gravityScale *= -1;

            sr.flipY = !sr.flipY;
        }
    }
}
