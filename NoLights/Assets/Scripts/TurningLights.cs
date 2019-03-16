using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningLights : MonoBehaviour
{
    private LightBehaviour currentLight;

    void Update()
    {
        if (currentLight != null && Input.GetKeyDown(KeyCode.Space))
            currentLight.switchLight();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentLight = collision.gameObject.GetComponent<LightBehaviour>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentLight = null;
    }
}
