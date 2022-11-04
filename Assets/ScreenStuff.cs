using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenStuff : MonoBehaviour
{
    public void fadeIn()
    {
        StartCoroutine(DoFadeIn());
    }

    IEnumerator DoFadeIn()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        while (cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime /2;
            yield return null;
        }
        yield return null;
    }
    public void fadeOut()
    {

    }
}

