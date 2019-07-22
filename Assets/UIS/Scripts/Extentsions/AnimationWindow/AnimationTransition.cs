namespace UIS
{
    using UnityEngine;
    using System.Collections;
    using System;
    public class AnimationTransition : MonoBehaviour, IAnimationWindow
    {
        private CanvasGroup canvas;
        private const float TIME_ANIMATION = 0.5f;

        private void OnEnable()
        {
            if (!canvas) canvas = GetComponent<CanvasGroup>();
            OnOpenWindowAnim();
        }


        public void OnCloseWinodwAnim(Action handlerClose)
        {
            StartCoroutine(AnimationCanvas(1, 0, handlerClose));
        }

        public void OnOpenWindowAnim()
        {
            StartCoroutine(AnimationCanvas(0, 1, null));
        }

        private IEnumerator AnimationCanvas(float start, float target, Action endAnimationHandler)
        {
            float elapsedTime = 0;

            while (elapsedTime < TIME_ANIMATION)
            {
                canvas.alpha = Mathf.Lerp(start, target, (elapsedTime / TIME_ANIMATION));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            canvas.alpha = target;

            if (endAnimationHandler != null)
                endAnimationHandler.Invoke();
        }
    }

}
