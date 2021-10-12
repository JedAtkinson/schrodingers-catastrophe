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

    public void LoadLevel(int sceneNumber)
    {
        StartCoroutine(LoadLevelCoroutine(sceneNumber));
    }

    IEnumerator LoadLevelCoroutine (int sceneNumber)
    {
        //Starts transition out/in
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        //Loads given sceneName
        SceneManager.LoadScene(sceneNumber);
    }
}
