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

        public virtual void Awake()
        {
            button = GetComponent<Button>();
            window = GetComponentInParent<Window>();
            if (!button || !window)
            {
                Destroy(this);
            }
        }

        public virtual void Start() => button.onClick.AddListener(delegate { Action(); });

        public virtual void Action()
        {

        }
    }
}
