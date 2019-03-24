using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyDoorProgresion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Player")
        {
            DoorManager.changeDoorStatus(this.gameObject);
        }
    }
}
