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
    }

    public void OnMusicSelection()
    {
        game_settings.music_id = music_selection.value;
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
