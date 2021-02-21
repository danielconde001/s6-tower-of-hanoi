using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AudioManager audioManager;

    private Resolution[] resolutions;
    private TMPro.TMP_Dropdown resolutionDropdown;

    private void Awake() {
        
        audioManager = FindObjectOfType<AudioManager>();

        if (!audioManager) 
        {
            GameObject newObj = (GameObject)Instantiate(Resources.Load("Audio Manager"));
            audioManager = newObj.GetComponent<AudioManager>();
        }

        GetResolutions();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResoltuion(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void GetResolutions()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown = 
            transform.Find("Settings Canvas").transform.Find("Screen Resolution Dropdown").GetComponent<TMPro.TMP_Dropdown>();

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
}
