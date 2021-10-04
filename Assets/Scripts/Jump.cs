﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float jumpForce;
    private float jumpInput;
    private bool isJumping;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gravity = GetComponent<Rigidbody2D>().gravityScale;

        jumpInput = Input.GetAxis("Jump");

        RaycastHit2D ray = Physics2D.Raycast(this.transform.position, new Vector2(0, -1 * gravity), Mathf.Infinity, LayerMask.GetMask("Platforms"));

        if (jumpInput > 0 && ray.distance <= 0.5f && isJumping == false)
        {
            isJumping = true;
            anim.SetTrigger("Jump");
            anim.SetBool("isWalking", false);
            rb.AddForce(new Vector2(0, jumpForce * gravity), ForceMode2D.Impulse);
        }
        if (jumpInput <= 0)
        {
            isJumping = false;
        }
    }
}