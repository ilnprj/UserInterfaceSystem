using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Модуль, обеспечивающий авто привязку элемента в слот.
/// </summary>
public class DropToSlotLerp : EventTrigger
{
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
        if (target!=rectTransform)
        {
            StartCoroutine(LerpToTarget());
        }
    }

    private IEnumerator LerpToTarget()
    {
        _lerping = true;
        rectTransform.SetParent(target);
        float elapsedTime = 0;
        while (elapsedTime < 1.0f && _lerping)
        {
            rectTransform.position = Vector3.Lerp(rectTransform.position, target.position, elapsedTime / 1.0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void StopLerp()
    {
        _lerping = false;
        StopCoroutine(LerpToTarget());
    }

    private RectTransform GetNearestRectTransform()
    {
        var nearestRect = rectTransform;
        float nearestDist = 250;
        float curDist;
        
        foreach (var item in  _allSlots)
        {
            curDist = Vector3.Distance(rectTransform.position, item.RectTransform.position);
            if (!(curDist < nearestDist)) continue;
            nearestDist = curDist;
            nearestRect = item.RectTransform;
        }
        return nearestRect;
    }
}
