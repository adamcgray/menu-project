using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
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
        settings = GameObject.FindWithTag("Settings");
        GameObject checkMenu = GameObject.FindWithTag("Main Menu");
        if (checkMenu != null)
        {
            Destroy(checkMenu);
            Instantiate(main_menu_screen, settings_menu_screen.transform.position, settings_menu_screen.transform.rotation);
            Destroy(settings);
        }
        else
        {
            Instantiate(main_menu_screen, settings_menu_screen.transform.position, settings_menu_screen.transform.rotation);
        }
        //Instantiate(settings_menu_screen, main_menu_screen.transform.position, main_menu_screen.transform.rotation);
        Destroy(settings);
    }

}
