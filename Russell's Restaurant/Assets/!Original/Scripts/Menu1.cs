using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class Menu1 : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixer2;
    Resolution[] resol;
    public Dropdown resDrop;

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        if (volume < -40)
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
    }
    public void SetSoundVolume(float volume)
    {
        audioMixer2.SetFloat("SoundVolume", volume);
        if (volume < -40)
        {
            audioMixer.SetFloat("SoundVolume", -80);
        }
    }
    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void FixedUpdate() 
    {
        Screen.SetResolution(1920, 1080, true);
    }
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        if (File.Exists(Application.persistentDataPath + "/stats.iseeyou"))
        {
            //DoNothing
        }
        else
        {
            SaveSystem.SavePlayer();
        }
        resol = Screen.resolutions;
        resDrop.ClearOptions();
        List<string> options = new List<string>();
        int cRI = 0;
        for (int i = 0; i < resol.Length; i++)
        {
            string option = resol[i].width + " x " + resol[i].height;
            options.Add(option);
            if (resol[i].width == Screen.width && resol[i].height == Screen.height)
            {
                cRI = i;
            }
        }
        resDrop.AddOptions(options);
        resDrop.value = cRI;
        resDrop.RefreshShownValue();
    }
    public void SetResolution (int resIndex)
    {
        Resolution resolution = resol[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void ExitGame()
    {
        Screen.SetResolution(1920, 1080, true);
        Application.Quit();
        Debug.Log("Quit");
    }

}
