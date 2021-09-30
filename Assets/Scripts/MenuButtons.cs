using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // On Scene Start
    void Start ()
    {
        //Get all users screen possible resolutions
        resolutions = Screen.resolutions;
        //Clears the resolution dropDown options
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        //Goes through each possible resolution
        for (int i = 0; i < resolutions.Length; i++)
        {
            //Makes formated string for resolution (width x height)
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            //If resolution i is the current resolution
            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //Adds all resolution options to dropdown
        resolutionDropdown.AddOptions(options);

        //Sets the current resolution to display
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Sets resolution when changed in ResolutionDropdown
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    //Loads given scene name
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Quits game
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    //Sets master volume from VolumeSlider (will impiment if sound added)
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
    }

    //Sets fullscreen from FullscreenToggle
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
