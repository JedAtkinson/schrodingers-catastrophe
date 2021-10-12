using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public bool frozen;

	public GameObject levelLoader;

	void Start()
	{
		frozen = false;
	}

	void Update()
	{
		if (!frozen)
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


		}
		if (!GameObject.FindWithTag("Dead_Cat").GetComponent<Dash>().swapFrozen)
		{
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

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "Goal")
        {
			levelLoader.GetComponent<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);

		}
	}
}
