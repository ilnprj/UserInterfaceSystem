using UnityEngine;

public class SlotsContainer : MonoBehaviour
{
    public RectSlot Slot;

    private void Awake()
    {
        Slot = FindObjectOfType<RectSlot>();
    }
}
