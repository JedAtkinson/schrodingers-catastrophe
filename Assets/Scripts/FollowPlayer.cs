using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject cat;
    public GameObject otherCat;
    private GameObject newCat;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            newCat = otherCat;
            otherCat = cat;
            cat = newCat;
        }

            float catDistance = cat.transform.position.x - otherCat.transform.position.x;
        if (catDistance < 10 && catDistance > -10)
        {
            this.transform.position = new Vector3(otherCat.transform.position.x + (catDistance / 2), this.transform.position.y, this.transform.position.z);
        }
        else
        {
            if (catDistance > 10)
            {
                this.transform.position = new Vector3(cat.transform.position.x - 5, this.transform.position.y, this.transform.position.z);
            }
            if (catDistance < -10)
            {
                this.transform.position = new Vector3(cat.transform.position.x + 5, this.transform.position.y, this.transform.position.z);
            }
        }
    }
}
