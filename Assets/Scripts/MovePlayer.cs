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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0) facing = 1;
        else if (direction < 0) facing = -1;
        rb.velocity = new Vector2(direction * playerSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.R))
        {
			rb.isKinematic = true;
            opp_pos = opposite.transform.position;
            opposite.transform.position = this.transform.position;
            this.transform.position = opp_pos;
            rb.isKinematic = false;
            rb.gravityScale *= -1;
        }
    }
}
