using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контейнер, который хранит в себе все слоты на сцене.
/// </summary>
public class SlotsContainer : MonoBehaviour
{
    [Header("Current Slots in Scene:")]
    public List<RectSlot> RectSlots = new List<RectSlot>();

    private void Awake()
    {
        //FIXME: Данное решение не подходит если на сцене есть отключенные слоты в других окнах Canvas. 
        var SlotsInScene = FindObjectsOfType<RectSlot>();
        
        foreach (var item in SlotsInScene)
        {
            RectSlots.Add(item);
        }
    }
}
