using UnityEngine.Events;
using UnityEngine;

namespace UIS
{
    public class ButtonEscape: MonoBehaviour
    {
        public UnityEvent customEventOnKey = default;

        [SerializeField]
        private bool closeOnKey = default;

        [SerializeField]
        private KeyCode key = KeyCode.Escape;

        private Window window;

        protected void Awake()
        {
            window = GetComponentInParent<Window>();
        }

        protected void Update()
        {
            if (Input.GetKeyDown(key)&&window.Focus)
            {
                Action();
            }
        }

        protected void Action()
        {
            if (window.Focus)
            {
                customEventOnKey?.Invoke();
                if (closeOnKey)
                window.OnClose();
            }
        }
    }
}