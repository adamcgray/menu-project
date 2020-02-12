using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
    public Dropdown objectSelection;

    public Dropdown weaponSelection;

    public GameObject tree;
    public GameObject house;
    public GameObject skyScraper;

    public GameObject spear;
    public GameObject sword;
    public GameObject cleaver;

    public GameObject menuScreen;
    public GameObject selectedObject;
    public GameObject selectedWeapon;



    // Start is called before the first frame update
    void Start()
    {
        selectedObject = tree;
        selectedWeapon = spear;
    }


    public void OnObjectSelection()
    {
        if (objectSelection.value == 0)
        {
            selectedObject = tree;
        }
        if (objectSelection.value == 1)
        {
            selectedObject = house;
        }
        if (objectSelection.value == 2)
        {
            selectedObject = skyScraper;
        }
    }

    public void OnWeaponSelection()
    {
        if (weaponSelection.value == 0)
        {
            selectedWeapon = spear;
        }
        if (weaponSelection.value == 1)
        {
            selectedWeapon = sword; 
        }
        if (weaponSelection.value == 2)
        {
            selectedWeapon = cleaver;
        }
    }

    public void OnSpawnClick()
    {
        Instantiate(selectedObject, menuScreen.transform.position, menuScreen.transform.rotation);
    }

    public void OnWeaponSpawnClick()
    {
        Instantiate(selectedWeapon, menuScreen.transform.position, menuScreen.transform.rotation);
    }
}

