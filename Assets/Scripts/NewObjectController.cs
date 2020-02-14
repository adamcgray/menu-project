using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewObjectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerClickHandler
{
    public Dropdown objectSelection;

    public GameObject tree;
    public GameObject house;
    public GameObject skyScraper;

    public GameObject menuScreen;
    public GameObject selectedObject;

    public GameObject player;

    public void Start()
    {
        selectedObject = tree;
    }

    public void OnObjectSelection(int objectSelected)
    {
        if (objectSelected == 0)
        {
            selectedObject = tree;
        }
        if (objectSelected == 1)
        {
            selectedObject = house;
        }
        if (objectSelected == 2)
        {
            selectedObject = skyScraper;
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
        Instantiate(selectedObject, spawnPos, playerRotation);
    }
}
