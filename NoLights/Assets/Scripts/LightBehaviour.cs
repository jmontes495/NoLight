using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public delegate void LightEvent();
    public static event LightEvent LightOn;
    public static event LightEvent LightOff;

    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    public void SwitchLight()
    {
        light.enabled = !light.enabled;
        NotifyLightState();
    }

    private void NotifyLightState()
    {
        if (light.enabled)
            LightOn();
        else
            LightOff();
    }
}
