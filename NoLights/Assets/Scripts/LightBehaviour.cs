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

    private Light torchLight;

    

    private bool canActivate = true;
    // Start is called before the first frame update
    void Start()
    {
        torchLight = GetComponent<Light>();
        torchOn.enabled = torchLight.enabled;
        LightsManager.AllLightsOut += EndLightSwitching;
    }

    private void EndLightSwitching()
    {
        canActivate = false;
    }

    public void SwitchLight()
    {
        if (!canActivate)
            return;

        torchLight.enabled = !torchLight.enabled;
        torchOn.enabled = torchLight.enabled;
        NotifyLightState();

        torchSounds();
    }

    private void NotifyLightState()
    {
        if (torchLight.enabled)
            LightOn();
        else
            LightOff();
    }

    private void torchSounds()
    {
        LightSoundManager.PlayLightsSounds(torchLight.enabled);
    }
}
