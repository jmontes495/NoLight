using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsManager : MonoBehaviour
{
    public delegate void LightManagerEvent();
    public static event LightManagerEvent AllLightsOut;
    public static event LightManagerEvent TurnedBackOneLight;

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
        if (lightsCount == 1)
            TurnedBackOneLight();
    }

    private void CountLightsDown()
    {
        lightsCount--;
        if (lightsCount == 0)
            AllLightsOut();
    }
}
