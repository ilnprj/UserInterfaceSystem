namespace UIS.Extensions.DragDrop
{
    using UnityEngine;

    /// <summary>
    /// Item слота, необходим для того чтобы SlotsContainer собрал все слоты на сцене.
    /// </summary>
    public class RectSlot : MonoBehaviour
    {
        [HideInInspector]
        public RectTransform RectTransform;

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }

}
