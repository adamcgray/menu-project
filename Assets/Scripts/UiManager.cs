using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public float smooth = 1f;
    // Game object
    public GameObject UiPanel;

    // materials
    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;

    // prefabs
    public GameObject tree;
    public GameObject house;
    public GameObject skyScraper;

    public GameObject spear;
    public GameObject sword;
    public GameObject cleaver;

    // Music Assets
    public AudioSource musicSource;
    public AudioSource musicTrack1;
    public AudioSource musicTrack2;
    public AudioSource musicTrack3;

    public Resolution[] resolutions;
    private GameSettings game_settings;
    private GameObject selectedObject;
    private GameObject selectedWeapon;

    private Vector3 targetAngles;

    void Start()
    {
        selectedObject = tree;
        selectedWeapon = spear;
        game_settings = new GameSettings();
        resolutions = Screen.resolutions;
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth * Time.deltaTime); // lerp to new angles
    }

    public void OnSkyboxSelection(int skybox)
    {
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

    public void OnObjectSelection(int obj)
    {
        if (obj == 0)
        {
            selectedObject = tree;
        }
        if (obj == 1)
        {
            selectedObject = house;
        }
        if (obj == 2)
        {
            selectedObject = skyScraper;
        }
    }

    public void OnWeaponSelection(int weapon)
    {
        if (weapon == 0)
        {
            selectedWeapon = spear;
        }
        if (weapon == 1)
        {
            selectedWeapon = sword;
        }
        if (weapon == 2)
        {
            selectedWeapon = cleaver;
        }
    }

    public void OnCreateObjectClick()
    {
        Instantiate(selectedObject, transform.position, transform.rotation);
    }

    public void OnCreateWeaponClick()
    {
        Instantiate(selectedWeapon, transform.position, transform.rotation);
    }

    public void onConfirmClick()
    {

        targetAngles = transform.eulerAngles + -180f * Vector3.up;
    }

    public void onSettingsButtonClick()
    {
        targetAngles = transform.eulerAngles + 180f * Vector3.up; // what the new angles should be
    }
}