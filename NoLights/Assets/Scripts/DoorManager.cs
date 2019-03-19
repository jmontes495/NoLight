using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    /*
     * 0 = Puerta normal
     * 1 = Ya hay raices
     * 2 = Puerta muchas raices
     * 3 = Puerta esta rota
     */
    private int currentStatus = 0;
    public GameObject firstRupture; // First state in wich the the fungus roots start appearing
    public GameObject advancedRupture; // More longer fungus roots covering the door
    public GameObject doorSprite; // The door 
    private bool allLightsOut = false;


    private void Start()
    {
        LightsManager.AllLightsOut += doorProgressCanHappen;
        LightsManager.TurnedBackOneLight += doorProgressIsSuspended;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        /*
         * Here should be a verification that ask wheter or not all lights are off
         * if so, the next question is asked, else the game does nothing.
         */ 
         if(allLightsOut)
        {
            if (triggerCollider.tag == "DoorProgresion")
            {
                changeDoorStatus(triggerCollider.gameObject);
            }
        }
    }

    private void doorProgressCanHappen()
    {
        allLightsOut = true;
    }

    private void doorProgressIsSuspended()
    {
        allLightsOut = false;
    }

    /// <summary>
    /// Changes the srpites that indicates the status of the door as well as changes the int that helps to identify the current status of the door
    /// </summary>
    private void changeDoorStatus(GameObject triggerColliderGO)
    {
        if(currentStatus==0)
        {
            firstRupture.SetActive(true);
        }
        else if(currentStatus==1)
        {
            firstRupture.SetActive(false);
            advancedRupture.SetActive(true);
        }
        else if(currentStatus==2)
        {
            firstRupture.SetActive(false);
            doorSprite.SetActive(false);
        }
        triggerColliderGO.SetActive(false);
        currentStatus++;
    }
}
