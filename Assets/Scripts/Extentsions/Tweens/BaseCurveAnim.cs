using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Базовый класс Tween.
/// </summary>
public class BaseCurveAnim : MonoBehaviour
{
    [Header("Кривая анимации:")]
    public AnimationCurve curveItem;
    [Header("Тип воспроизведения анимации:")]
    public TypeAnimation TypePlayCurve;
    [Header("Длительность анимации:")]
    public float Duration = 1.0f;
    [Header("Задержка перед анимацией:")]
    public float DelaySeconds = 0.0f;

    [HideInInspector] public int KoefAnim = 0;
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

    public IEnumerator DelayBeforeAnim()
    {
        yield return  new WaitForSecondsRealtime(DelaySeconds);
        KoefAnim = 1;
    }

    public void OnFinishedAnimation()
    {
        if (Mode == WrapMode.Once)
        {
            eventOnFinished.Invoke();
        }
    }

    public void Update()
    {
        CalculateCurve();
    }
    
    public void CalculateCurve()
    {
        GraphValue = curveItem.Evaluate((1/Duration)*Time.time*KoefAnim);
    }
}
