using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject cat;
    public GameObject otherCat;
    private GameObject newCat;

    public float xMin;
    public float xMax;
    private float cameraY;
    private float cameraX;

    private Camera cam;
    public GameObject[] edges;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        float width = cam.orthographicSize * cam.aspect;

        edges = GameObject.FindGameObjectsWithTag("WorldEdge");

        xMin = Mathf.Min((edges[0].transform.position.x), (edges[1].transform.position.x)) + width + 2;
        xMax = Mathf.Max((edges[0].transform.position.x), (edges[1].transform.position.x)) - width - 2;
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
            cameraX = otherCat.transform.position.x + (catDistance / 2);
        }
        else
        {
            if (catDistance > 10)
            {
                cameraX = cat.transform.position.x - 5;
            }
            if (catDistance < -10)
            {
                cameraX = cat.transform.position.x + 5;
            }
        }

        //Update position
        this.transform.position = new Vector3(Mathf.Clamp(cameraX, xMin, xMax), this.transform.position.y, this.transform.position.z);
    }
}
