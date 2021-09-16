using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float direction;
    public Rigidbody2D rb;
    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * playerSpeed, 0); 
    }
}
