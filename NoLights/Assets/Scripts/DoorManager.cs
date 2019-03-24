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
    private static int currentStatus = 0;

    public Sprite firstStateSprite;
    public Sprite SecondStateSprite;
    public Sprite finalStateSprite;
    public SpriteRenderer SR;

    public static Sprite firstSatateStatic; // First state in wich the the fungus roots start appearing
    public static Sprite secondSatateStatic; // More longer fungus roots covering the door
    public static Sprite finalStateStatic;
    private static bool allLightsOut = false;

    public static SpriteRenderer SR_Static;

    private void Start()
    {
        firstSatateStatic = firstStateSprite;
        secondSatateStatic = SecondStateSprite;
        finalStateStatic = finalStateSprite;
        SR_Static = SR;

        LightsManager.AllLightsOut += doorProgressCanHappen;
        LightsManager.TurnedBackOneLight += doorProgressIsSuspended;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        Debug.Log("Collide");
        
    }

    private void doorProgressCanHappen()
    {
        Debug.Log("Luces apagadas");
        allLightsOut = true;
    }

    private void doorProgressIsSuspended()
    {
        Debug.Log("Luces prendidas");
        allLightsOut = false;
    }

    /// <summary>
    /// Changes the srpites that indicates the status of the door as well as changes the int that helps to identify the current status of the door
    /// </summary>
    public static void changeDoorStatus(GameObject triggerColliderGO)
    {
        if (allLightsOut)
        {
            if (currentStatus == 0)
            {
                Debug.Log("status primero");

                SR_Static.sprite = firstSatateStatic;
            }
            else if (currentStatus == 1)
            {
                Debug.Log("status segundo");

                SR_Static.sprite = secondSatateStatic;
            }
            else if (currentStatus == 2)
            {
                Debug.Log("status tercero");

                SR_Static.sprite = finalStateStatic;
            }
            triggerColliderGO.SetActive(false);
            currentStatus++;

            DoorSoundsManager.playDoorSounds(currentStatus);
        }
    }
}
