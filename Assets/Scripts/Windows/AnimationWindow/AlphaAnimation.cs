using UnityEngine;
using System.Collections;
using System;
public class AlphaAnimation : MonoBehaviour, IAnimationWindow
{
    private CanvasGroup canvas;
    private const float TIME_ANIMATION = 0.5f;

    private void OnEnable()
    {
        if (!canvas) canvas = GetComponent<CanvasGroup>();
        StartCoroutine(AnimationCanvas(0, 1));
    }


    public void OnCloseWinodwAnim()
    {
        throw new System.NotImplementedException();
    }

    public void OnOpenWindowAnim()
    {
        throw new System.NotImplementedException();
    }

    private IEnumerator AnimationCanvas(float start, float target)
    {
        float elapsedTime = 0;
        
        while (elapsedTime < TIME_ANIMATION)
        {
            canvas.alpha = Mathf.Lerp(start, target, (elapsedTime / TIME_ANIMATION));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    

    
}
