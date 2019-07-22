namespace UIS.Extensions.Animations
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// Base class Tween Anim
    /// </summary>
    public class BaseCurveAnim : MonoBehaviour
    {
        [Header("Curve animation:")]
        public AnimationCurve curveItem;
        [Header("Type playpack animation:")]
        public TypeAnimation TypePlayCurve;
        [Header("Lengh Animation:")]
        public float Duration = 1.0f;
        [Header("Delay:")]
        public float DelaySeconds;

        [HideInInspector] public int KoefAnim;
        public enum TypeAnimation
        {
            Once,
            Loop,
            PingPong
        }

        public UnityEvent eventOnFinished;
        [HideInInspector]
        public float GraphValue;

        public BaseCurveAnim()
        {
            curveItem = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));
        }
        public virtual void Start()
        {
            curveItem.postWrapMode = Mode;
            StartCoroutine(DelayBeforeAnim());
        }

        public WrapMode Mode
        {
            get
            {
                switch (TypePlayCurve)
                {
                    case TypeAnimation.Once:
                        {
                            return WrapMode.Once;
                        }

                    case TypeAnimation.Loop:
                        {
                            return WrapMode.Loop;
                        }


                    case TypeAnimation.PingPong:
                        {
                            return WrapMode.PingPong;
                        }

                    default: return WrapMode.Once;
                }
            }
        }

        private IEnumerator DelayBeforeAnim()
        {
            yield return new WaitForSecondsRealtime(DelaySeconds);
            KoefAnim = 1;

            if (Mode != WrapMode.Once) yield break;
            yield return new WaitForSecondsRealtime(curveItem.keys[curveItem.keys.Length - 1].time);
            OnFinishedAnimation();
        }

        private void OnFinishedAnimation()
        {
            eventOnFinished.Invoke();
        }

        public void Update()
        {
            CalculateCurve();
        }

        public void CalculateCurve()
        {
            GraphValue = curveItem.Evaluate((1 / Duration) * Time.time * KoefAnim);
        }
    }
}