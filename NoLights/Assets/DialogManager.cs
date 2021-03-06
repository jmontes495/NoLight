﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private string finalText;

    private TextMeshProUGUI dialog;

    private Image background;

    void Start()
    {
        LightBehaviour.LightOn += DisappearInitialDialog;
        LightBehaviour.LightOff += DisappearInitialDialog;
        LightsManager.AllLightsOut += ShowFinalDialog;

        dialog = GetComponent<TextMeshProUGUI>();
        dialog.color = new Color(1f, 1f, 1f, 0f);

        background = GetComponentInChildren<Image>();
        StartCoroutine(FadeIn());
    }

    private void DisappearInitialDialog()
    {
        StopAllCoroutines();
        LightBehaviour.LightOn -= DisappearInitialDialog;
        LightBehaviour.LightOff -= DisappearInitialDialog;
        StartCoroutine(FadeOut());
    }

    private void ShowFinalDialog()
    {
        StopAllCoroutines();
        dialog.text = finalText;
        dialog.color = new Color(0f, 1f, 1f, 0f);
        LightsManager.AllLightsOut -= ShowFinalDialog;
        StartCoroutine(FadeInAndGlow());
    }

    private IEnumerator FadeOut()
    {
        for (float i = 1f; i > 0; i -= 0.01f)
        {
            dialog.color = new Color(1f, 1f, 1f, i);
            if(i <= 0.8f)
                background.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(Random.Range(0, 1));
        for (float i = 0f; i < 1; i += 0.01f)
        {
            dialog.color = new Color(1f, 1f, 1f, i);
            if (i <= 0.8f)
                background.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator FadeInAndGlow()
    {
        yield return new WaitForSeconds(Random.Range(0, 1));
        for (float i = 0f; i < 1; i += 0.01f)
        {
            dialog.color = new Color(0f, 1f, 1f, i);
            if (i <= 0.8f)
                background.color = new Color(0f, 0f, 0f, i);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(Glow());
    }

    private IEnumerator Glow()
    {
        while (true)
        {
            for (float i = 1f; i > 0.7f; i -= 0.01f)
            {
                dialog.color = new Color(0f, 1f, 1f, i);
                yield return new WaitForSeconds(0.05f);
            }

            for (float i = 0.7f; i < 1; i += 0.01f)
            {
                dialog.color = new Color(0f, 1f, 1f, i);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
