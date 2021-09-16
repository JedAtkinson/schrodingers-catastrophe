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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(direction * playerSpeed, 0);
        if (Input.GetKeyDown("space"))
        {
            opposite.SetActive(false);
            opp_pos = opposite.transform.position;
            opposite.transform.position = this.transform.position;
            this.transform.position = opp_pos;
            opposite.SetActive(true);
        }
        
    }
}
