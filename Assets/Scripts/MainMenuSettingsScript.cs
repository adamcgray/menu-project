using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuSettingsScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
{
    public GameObject settings;
    public GameObject mainMenu;

    public GameObject main_menu_screen;
    public GameObject settings_menu_screen;


    private void Awake()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {


    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mainMenu = GameObject.FindWithTag("Main Menu");
        GameObject checkSettings = GameObject.FindWithTag("Settings");
        if (checkSettings != null)
        {
            Destroy(checkSettings);
            Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
            Destroy(mainMenu);
        }
        else
        {
            Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
        }
        //Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
        Destroy(mainMenu);

    }
}

