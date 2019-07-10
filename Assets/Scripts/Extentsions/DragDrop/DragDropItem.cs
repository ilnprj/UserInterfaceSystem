using UnityEngine.EventSystems;
using UnityEngine;

public class DragDropItem : EventTrigger
{
    public override void OnPointerDown(PointerEventData eventData)
    {

    }

    public override void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
       
    }
}
