using System;
using UnityEngine;
public class RectSlot : MonoBehaviour
{
    [HideInInspector]
    public RectTransform RectTransform;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}
