namespace UIS.Extensions.Swipe
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.EventSystems;

    /// <summary>
    /// Swipe Image Controller with custom Unity Events
    /// </summary>
    public class SwipeImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 Start, End;
        public UnityEvent eventHorizontal = new UnityEvent();
        public UnityEvent eventVertical = new UnityEvent();
        private const int LENGHT_SWIPE = 100;

        public void OnPointerDown(PointerEventData eventData)
        {
            Start = eventData.position;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            End = eventData.position;
            SetSwipe(Start, End);
        }

        private void SetSwipe(Vector2 aPoint, Vector2 bPoint)
        {
            Vector2 res = aPoint - bPoint;

            if (res.x > LENGHT_SWIPE)
            {
                eventHorizontal.Invoke();
            }
            if (res.x < -LENGHT_SWIPE)
            {
                eventHorizontal.Invoke();
            }

            if (res.y > LENGHT_SWIPE)
            {
                eventVertical.Invoke();
            }

            if (res.y < -LENGHT_SWIPE)
            {
                eventVertical.Invoke();
            }
        }
    }
}

