using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 Start, End;
    private UnityEvent eventHorizontal;
    private UnityEvent eventVertical;
    private const int LENGHT_SWIPE = 80;
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
        float xSwipe, ySwipe;
        xSwipe = res.x / Screen.width;
        ySwipe = res.y / Screen.height;

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
