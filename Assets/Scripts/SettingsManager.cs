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

    public GameObject player;
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
    void Update()
    {
        //if (SteamVR._default.inActions.MenuClick.GetStateDown(inputSource))
        //{
            //GameObject checkMenu = GameObject.FindWithTag("Main Menu");
            //Destroy(checkMenu);
            //GameObject checkSettings = GameObject.FindWithTag("Settings");
            //Destroy(checkSettings);
            //Instantiate(main_menu_screen, player.transform.position, player.transform.rotation);// the menu button on the controller
        //}
    }

    void OnEnable()
    {
        game_settings = new GameSettings();

        //skybox_selection.onValueChanged.AddListener(delegate { OnSkyboxSelection(); });
        //music_selection.onValueChanged.AddListener(delegate { OnMusicSelection(); });
        //music_volume.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        //confirmButton.onClick.AddListener(delegate { onButtonClick(); });
        //settingsButton.onClick.AddListener(delegate { onSettingsButtonClick(); });

        resolutions = Screen.resolutions;
    }

    public void OnSkyboxSelection(int skybox)
    {
        //game_settings.skybox_id = skybox;
        if (skybox == 0)
        {
            RenderSettings.skybox = skyOne;
        } else if (skybox == 1)
        {
            RenderSettings.skybox = skyTwo;
        } else if (skybox == 2)
        {
            RenderSettings.skybox = skyThree;
        }
    }

    public void OnMusicSelection(int music)
    {
        //game_settings.music_id = music;
        if (music == 0)
        {
            musicSource.Stop();
            musicSource = musicTrack1;
            musicSource.Play();
        } else if (music == 1)
        {
            musicSource.Stop();
            musicSource = musicTrack2;
            musicSource.Play();
        } else if (music == 2)
        {
            musicSource.Stop();
            musicSource = musicTrack3;
            musicSource.Play();
        }
    }

    public void OnMusicVolumeChange(float volume)
    {
        musicSource.volume = volume;
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