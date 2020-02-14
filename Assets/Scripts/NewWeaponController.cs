using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewWeaponController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
{

    public Dropdown weaponSelection;


    public GameObject spear;
    public GameObject sword;
    public GameObject cleaver;

    public GameObject menuScreen;
    public GameObject selectedWeapon;

    public GameObject player;

    public void Start()
    {
        selectedWeapon = spear;
    }

    public void OnWeaponSelection(int weaponSelected)
        {
            if (weaponSelected == 0)
            {
                selectedWeapon = spear;
            }
            if (weaponSelected == 1)
            {
                selectedWeapon = sword;
            }
            if (weaponSelected == 2)
            {
                selectedWeapon = cleaver;
            }
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
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 10;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        Instantiate(selectedWeapon, spawnPos, playerRotation);
    }
}