// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.DragDrop
{
    using UnityEngine.EventSystems;
    using UnityEngine;

    public class DragDropItem : EventTrigger
    {
        private const float MIN_TIME_TO_DRAG = 1.0f;
        private float timeHold;
        private bool pressed;

        public override void OnPointerDown(PointerEventData eventData)
        {
            pressed = true;
        }

        private void Update()
        {
            if (pressed)
            {
                timeHold += Time.unscaledDeltaTime;
            }
        }

        public override void OnDrag(PointerEventData eventData)
        {
            if (timeHold >= MIN_TIME_TO_DRAG)
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            pressed = false;
            timeHold = 0f;
        }
    }
}
