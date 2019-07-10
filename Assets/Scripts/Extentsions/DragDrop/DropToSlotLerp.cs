using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropToSlotLerp : EventTrigger
{
    private RectTransform target;
    private RectTransform RectTransform;
    private void Start()
    {
        target = FindObjectOfType<SlotsContainer>().Slot.RectTransform;
        RectTransform = GetComponent<RectTransform>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        StopCoroutine(LerpToTarget());
    }

    public override void OnDrag(PointerEventData eventData)
    {
        StopCoroutine(LerpToTarget());
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(LerpToTarget());
    }

    private IEnumerator LerpToTarget()
    {
        float elapsedTime = 0;
        while (elapsedTime < 1.0f)
        {
            RectTransform.position = Vector3.Lerp(RectTransform.position, target.position, elapsedTime / 1.0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
