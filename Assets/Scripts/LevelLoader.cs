using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //Can change animation to any animated object (black fade place holder)

    public Animator transition;
    // length of each animation (fade out: 0.5s, fade in: 0.5s)
    public float transitionTime = 0.5f;

    public GameObject BlackScreen;

    public void LoadLevel(int sceneNumber)
    {
        StartCoroutine(LoadLevelCoroutine(sceneNumber));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !GameObject.FindWithTag("Dead_Cat").GetComponent<Dash>().swapFrozen)
        {
            StartCoroutine(BlackSwitchScreen());
        }
    }

    IEnumerator LoadLevelCoroutine (int sceneNumber)
    {
        //Starts transition out/in
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Loads given sceneName
        SceneManager.LoadScene(sceneNumber);
    }

    IEnumerator BlackSwitchScreen()
    {
        BlackScreen.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        BlackScreen.SetActive(false);
    }
}
