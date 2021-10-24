using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject levelLoader;
    public GameObject otherGoal;
    public bool onGoal = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Dead_Cat" || collider.tag == "Live_Cat")
        {
            onGoal = true;
            if (otherGoal.GetComponent<Goal>().onGoal == true)
            {
                levelLoader.GetComponent<LevelLoader>().LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Dead_Cat" || collider.tag == "Live_Cat")
        {
            onGoal = false;
        }
    }
}
