// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------


namespace UIS
{
    using UnityEngine;
    using UnityEngine.UI;
    
    [RequireComponent(typeof(Button))]
    public abstract class ButtonBaseBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public Button button;

        [HideInInspector]
        public Window window;

        protected virtual void Awake()
        {
            button = GetComponent<Button>();
            window = GetComponentInParent<Window>();
            if (!button || !window)
            {
                Destroy(this);
            }
        }

        protected virtual void Start() => button.onClick.AddListener(delegate { Action(); });

        /// <summary>
        /// Action on button. Need to be implement
        /// </summary>
        protected abstract void Action();
    }
}
