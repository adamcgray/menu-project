using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject[] settings;
    public GameObject[] mainMenus;
    public GameObject[] confirmButtons;
    public GameObject[] settingsButtons;
    public GameObject main_menu_screen;
    public GameObject settings_menu_screen;
    public Dropdown skybox_selection;
    public Dropdown music_selection;
    public Slider music_volume;
    public AudioSource musicSource;
    public Button confirmButton;
    public Button settingsButton;

    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;

    public AudioSource musicTrack1;
    public AudioSource musicTrack2;
    public AudioSource musicTrack3;

    public Resolution[] resolutions;
    private GameSettings game_settings;

    void Update()
    {
        confirmButtons = GameObject.FindGameObjectsWithTag("ConfirmButton");
        foreach (GameObject confirmButton in confirmButtons)
        {
            Button actualConfirmButton = confirmButton.GetComponent(typeof(Button)) as Button;
            actualConfirmButton.onClick.AddListener(delegate { onButtonClick(); });
        }
        settingsButtons = GameObject.FindGameObjectsWithTag("SettingsButton");
        foreach (GameObject settingsButton in settingsButtons)
        {
            Button actualSettingsButton = settingsButton.GetComponent(typeof(Button)) as Button;
            actualSettingsButton.onClick.AddListener(delegate { onSettingsButtonClick(); });
        }

    }
    void OnEnable()
    {
        game_settings = new GameSettings();

        skybox_selection.onValueChanged.AddListener(delegate { OnSkyboxSelection(); });
        music_selection.onValueChanged.AddListener(delegate { OnMusicSelection(); });
        music_volume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        confirmButton.onClick.AddListener(delegate { onButtonClick(); });
        settingsButton.onClick.AddListener(delegate { onSettingsButtonClick(); });

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

    public void onButtonClick()
    {
        int counter = 0;
        GameObject clone = null;
        settings = GameObject.FindGameObjectsWithTag("Settings");
        foreach (GameObject settings_menu in settings)
        {
            if (clone != null)
            {

            }
            else
            {
                clone = (GameObject) Instantiate(main_menu_screen, settings_menu_screen.transform.position, settings_menu_screen.transform.rotation);
                game_settings.current_menu = clone;
                counter++;
            }
        Destroy(settings_menu);
        }
    }

    public void onSettingsButtonClick()
    {
        int counter2 = 0;
        GameObject clone = null;
        mainMenus = GameObject.FindGameObjectsWithTag("Main Menu");
        foreach (GameObject main_menu in mainMenus)
        {
            if (clone != null)
            {

            } else
            {
                clone = (GameObject) Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
                game_settings.current_menu = clone;
                counter2++;
            }
        Destroy(main_menu);
        }
    }
}