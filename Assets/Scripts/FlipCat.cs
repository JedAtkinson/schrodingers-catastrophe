using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCat : MonoBehaviour
{
    private GameObject deadCat;

    private void Start() {
        deadCat = GameObject.FindWithTag("Dead_Cat");
    }
    void Update()
    {
        //Yes, I created a new script just to flip the fucking cat sprites properly if they go out of sync, it was annoying and now it isn't.
        if (Input.GetKeyDown(KeyCode.R)){
			if (GetComponent<SpriteRenderer>().flipX != deadCat.GetComponent<SpriteRenderer>().flipX)
			{
				GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
				deadCat.GetComponent<SpriteRenderer>().flipX = !deadCat.GetComponent<SpriteRenderer>().flipX;
			}
        }
    }
}
