using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Toggle toggle;
    private bool isFull;
    private int resolutionIndex;

    Resolution[] resolutions;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    private void FixedUpdate()
    {
        int i = resolutionDropdown.value;
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        resolutionDropdown.RefreshShownValue();

    }


    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();

    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");

    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void SetFullScreen()
    {     
        if(toggle.isOn)
        {
            isFull = true;
        }
        else
        {
            isFull = false;
        }
        Screen.fullScreen = toggle.isOn;
    }

    public void SetResolution()
    {
        resolutionIndex = resolutionDropdown.value;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
