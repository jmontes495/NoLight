﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooorAppearingBehaviour : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 0f);
        LightsManager.AllLightsOut += Show;
        LightsManager.TurnedBackOneLight += Hide;
    }

    private void Show()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    private void Hide()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(Random.Range(0, 5));
        for (float i = 0f; i < 1; i += 0.01f)
        {
            sr.color = new Color(1f, 1f, 1f, i);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator FadeOut()
    {
        for (float i = 1f; i > 0; i -= 0.01f)
        {
            sr.color = new Color(1f, 1f, 1f, i);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
