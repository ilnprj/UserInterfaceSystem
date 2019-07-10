using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropToSlotLerp : EventTrigger
{
    private RectTransform target;
    private RectTransform RectTransform;
    private bool lerping;
    private void Start()
    {
        target = FindObjectOfType<SlotsContainer>().Slot.RectTransform;
        RectTransform = GetComponent<RectTransform>();
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
        if (Vector3.Distance(RectTransform.position, target.position) < 200.0f)
        {
            StartCoroutine(LerpToTarget());
        }
    }

    private IEnumerator LerpToTarget()
    {
        lerping = true;
        float elapsedTime = 0;
        while (elapsedTime < 1.0f && lerping)
        {
            RectTransform.position = Vector3.Lerp(RectTransform.position, target.position, elapsedTime / 1.0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private void StopLerp()
    {
        lerping = false;
        StopCoroutine(LerpToTarget());
    }
}
