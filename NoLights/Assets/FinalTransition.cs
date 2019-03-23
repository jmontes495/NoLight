using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalTransition : MonoBehaviour
{
    public delegate void FinalGameEvent();
    public static event FinalGameEvent GameEnded;

    [SerializeField]
    private Image background;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Image image;

    private bool hasReachedEnding = false;

    private bool hasTurnedOutAllLights = false;

    void Start()
    {
        LightsManager.AllLightsOut += TurnedAllLights;
    }

    private void TurnedAllLights()
    {
        hasTurnedOutAllLights = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasReachedEnding || !hasTurnedOutAllLights)
            return;

        hasReachedEnding = true;
        StartFinalSequence();
    }

    private void StartFinalSequence()
    {
        GameEnded();
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(Random.Range(0, 5));
        for (float i = 0f; i < 1; i += 0.01f)
        {
            image.color = new Color(1f, 1f, 1f, i);
            background.color = new Color(0f, 0f, 0f, i*5);
            text.color = new Color(0f, 1f, 1f, i);
            yield return new WaitForSeconds(0.02f);
        }
    }

}
