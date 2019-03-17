using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    public delegate void LightEvent();
    public static event LightEvent LightOn;
    public static event LightEvent LightOff;

    [SerializeField]
    private SpriteRenderer torchOn;

    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        torchOn.enabled = light.enabled;
    }

    public void SwitchLight()
    {
        light.enabled = !light.enabled;
        torchOn.enabled = light.enabled;
        NotifyLightState();
    }

    private void NotifyLightState()
    {
        if (LightOn == null || LightOff == null)
            Debug.LogWarning("D:");

        if (light.enabled)
            LightOn();
        else
            LightOff();
    }
}
