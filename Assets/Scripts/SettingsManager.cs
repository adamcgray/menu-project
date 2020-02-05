using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Dropdown skybox_selection;
    public Dropdown music_selection;
    public Slider music_volume;
    public AudioSource musicSource;

    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;

    public AudioSource musicTrack1;
    public AudioSource musicTrack2;
    public AudioSource musicTrack3;


    public Resolution[] resolutions;
    private GameSettings game_settings;

    void OnEnable()
    {
        game_settings = new GameSettings();

        skybox_selection.onValueChanged.AddListener(delegate { OnSkyboxSelection(); });
        music_selection.onValueChanged.AddListener(delegate { OnMusicSelection(); });
        music_volume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        resolutions = Screen.resolutions;
    }

    public void OnSkyboxSelection()
    {
        game_settings.skybox_id = skybox_selection.value;
        if (game_settings.skybox_id == 0)
        {
            RenderSettings.skybox = skyOne;
        } else if (game_settings.skybox_id == 1)
        {
            RenderSettings.skybox = skyTwo;
        } else if (game_settings.skybox_id == 2)
        {
            RenderSettings.skybox = skyThree;
        }
    }

    public void OnMusicSelection()
    {
        game_settings.music_id = music_selection.value;
        if (game_settings.music_id == 0)
        {
            musicSource.Stop();
            musicSource = musicTrack1;
            musicSource.Play();
        } else if (game_settings.music_id == 1)
        {
            musicSource.Stop();
            musicSource = musicTrack2;
            musicSource.Play();
        } else if (game_settings.music_id == 2)
        {
            musicSource.Stop();
            musicSource = musicTrack3;
            musicSource.Play();
        }
    }

    public void OnMusicVolumeChange()
    {
        musicSource.volume = game_settings.music_volume = music_volume.value;
    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }
}
