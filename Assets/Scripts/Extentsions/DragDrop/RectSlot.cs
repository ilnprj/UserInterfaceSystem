using System;
using UnityEngine;
public class RectSlot : MonoBehaviour
{
    public RectTransform RectTransform;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}
