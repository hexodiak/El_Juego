using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        var options = new System.Collections.Generic.List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //Opciones de resoluciones
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        // Leer el índice guardado si existe
        int savedResolutionIndex = PlayerPrefs.GetInt("resolutionIndex", currentResolutionIndex);
        bool isFullscreen = PlayerPrefs.GetInt("fullscreen", 1) == 1;

        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = isFullscreen;

        ApplyResolution(savedResolutionIndex, isFullscreen); ; // Aplicar al inicio

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChange);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggle);
    }

    void OnResolutionChange(int resolutionIndex)
    {
        ApplyResolution(resolutionIndex, fullscreenToggle.isOn);

        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        PlayerPrefs.Save();
    }

    void OnFullscreenToggle(bool isFullscreen)
    {
        ApplyResolution(resolutionDropdown.value, isFullscreen);

        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    void ApplyResolution(int index, bool isFullscreen)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, isFullscreen);
    }
}
