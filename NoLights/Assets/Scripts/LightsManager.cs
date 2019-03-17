using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{

    private int lightsCount;

    void Start()
    {
        LightBehaviour.LightOn += CountLightsUp;
        LightBehaviour.LightOff += CountLightsDown;

        Light[] lightsInScene = FindObjectsOfType<Light>();
        foreach (Light light in lightsInScene)
        {
            if (light.enabled)
                lightsCount++;
        }
    }

    private void CountLightsUp()
    {
        lightsCount++;
    }

    private void CountLightsDown()
    {
        lightsCount--;
    }
}
