using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settings;
    public GameObject mainMenu;

    public GameObject main_menu_screen;
    public GameObject settings_menu_screen;
    public Dropdown skybox_selection;
    public Dropdown music_selection;
    public Slider music_volume;
    public AudioSource musicSource;
    public GameObject confirmButton;
    public GameObject settingsButton;

    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;

    public AudioSource musicTrack1;
    public AudioSource musicTrack2;
    public AudioSource musicTrack3;

    public Resolution[] resolutions;
    private GameSettings game_settings;

    private GameObject clone = null;
    private GameObject clone2 = null;

    //void Update()
    //{
        //confirmButton = GameObject.FindWithTag("ConfirmButton");
        //Button actualConfirmButton = confirmButton.GetComponent(typeof(Button)) as Button;
        //actualConfirmButton.onClick.AddListener(delegate { onButtonClick(); });
        //settingsButton = GameObject.FindWithTag("SettingsButton");
        //Button actualSettingsButton = settingsButton.GetComponent(typeof(Button)) as Button;
        //actualSettingsButton.onClick.AddListener(delegate { onSettingsButtonClick(); });

    //}
    void OnEnable()
    {
        game_settings = new GameSettings();

        skybox_selection.onValueChanged.AddListener(delegate { OnSkyboxSelection(); });
        music_selection.onValueChanged.AddListener(delegate { OnMusicSelection(); });
        music_volume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        //confirmButton.onClick.AddListener(delegate { onButtonClick(); });
        //settingsButton.onClick.AddListener(delegate { onSettingsButtonClick(); });

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
        settings = GameObject.FindWithTag("Settings");
        GameObject checkMenu = GameObject.FindWithTag("Main Menu");
        if (checkMenu != null) {
            Destroy(checkMenu);
            Instantiate(main_menu_screen, settings_menu_screen.transform.position, settings_menu_screen.transform.rotation);
            Destroy(settings);
        }
        else {
            Instantiate(main_menu_screen, settings_menu_screen.transform.position, settings_menu_screen.transform.rotation);
        }
        //Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
        Destroy(settings);
    }

    public void onSettingsButtonClick()
    {
        mainMenu = GameObject.FindWithTag("Main Menu");
        GameObject checkSettings = GameObject.FindWithTag("Settings");
        if (checkSettings != null)
        {
            Destroy(checkSettings);
            Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
            Destroy(mainMenu);
        } else {
            Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
        }
        //Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
        Destroy(mainMenu);

    }
}