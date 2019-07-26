// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.DragDrop
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// A container that holds all the slots on the stage.
    /// /// </summary>
    public class SlotsContainer : MonoBehaviour
    {
        [Header("Current Slots in Scene:")]
        public List<RectSlot> RectSlots = new List<RectSlot>();

        private void Awake()
        {
            var SlotsInScene = FindObjectsOfType<RectSlot>();

            foreach (var item in SlotsInScene)
            {
                RectSlots.Add(item);
            }
        }
    }
}
