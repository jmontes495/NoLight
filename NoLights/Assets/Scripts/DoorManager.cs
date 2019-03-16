using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    /**
     * 0 = Puerta normal
     * 1 = Ya hay raices
     * 2 = Puerta muchas raices
     * 3 = Puerta esta rota
     */
    private int currentStatus = 0;
    public GameObject puertaInicial;
    public GameObject puertaIntermedia;
    public GameObject PuertaMuchasRaices;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            changeDoorStatus();
            print("Current Status: " + currentStatus);
        }
    }

    private void changeDoorStatus()
    {
        if(currentStatus==0)
        {
            puertaInicial.SetActive(false);
            currentStatus++;
        }
        else if(currentStatus==1)
        {
            puertaIntermedia.SetActive(false);
            currentStatus++;
        }
        else if(currentStatus==2)
        {
            PuertaMuchasRaices.SetActive(false);
            currentStatus++;
        }
    }
}
