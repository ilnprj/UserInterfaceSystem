// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.DragDrop
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class DropToSlotLerp : EventTrigger
    {
        private const float MIN_DISTANCE_LERP = 250.0f;
        private RectTransform target;
        private RectTransform rectTransform;
        private List<RectSlot> _allSlots = new List<RectSlot>();
        private bool _lerping;

        private void Start()
        {
            _allSlots = FindObjectOfType<SlotsContainer>().RectSlots;
            rectTransform = GetComponent<RectTransform>();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            StopLerp();
        }

        public override void OnDrag(PointerEventData eventData)
        {
            StopLerp();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            target = GetNearestRectTransform();
            if (target != rectTransform)
            {
                StartCoroutine(LerpToTarget());
            }
        }

        private IEnumerator LerpToTarget()
        {
            _lerping = true;
            float elapsedTime = 0;
            while (elapsedTime < 1.0f && _lerping)
            {
                rectTransform.position = Vector3.Lerp(rectTransform.position, target.position, elapsedTime / 1.0f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            rectTransform.SetParent(target);
        }

        private void StopLerp()
        {
            _lerping = false;
            StopCoroutine(LerpToTarget());
        }

        private RectTransform GetNearestRectTransform()
        {
            var nearestRect = rectTransform;
            var nearestDist = MIN_DISTANCE_LERP * MIN_DISTANCE_LERP;
            float curDist;

            foreach (var item in _allSlots)
            {
                //Нам не нужно учитывать выключенные элементы
                if (!item.gameObject.activeSelf) continue;
                curDist = Vector3.SqrMagnitude(rectTransform.position - item.RectTransform.position);
                //Не учитываем элементы которые находятся дальше чем остальные либо за пределами зоны сброса в слот.
                if (!(curDist < nearestDist)) continue;
                nearestDist = curDist;
                nearestRect = item.RectTransform;
            }
            return nearestRect;
        }
    }
}