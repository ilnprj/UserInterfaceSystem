// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    using UnityEngine;
    using System;

    /// <summary>
    /// Base class Window, that implement interface IWindow
    /// </summary>
    public class Window : MonoBehaviour, IWindow
    {
        [HideInInspector]
        public string IdWindow;
        public Action RefreshWindowHandler = delegate { };
        public Action <bool> ChangeFocusHandler = delegate { };
        private bool focus;

        public bool Focus
        {
            get
            {
                return focus;
            }

            set
            {
                if (value)
                {
                    RefreshWindowHandler?.Invoke();
                }
                focus = value;
                ChangeFocusHandler?.Invoke(value);
            }
        }

        private new IAnimationWindow animation;
        private Action handlerClose = delegate { };

        public virtual void OnEnable()
        {
            OnOpen();
        }

        private void Awake()
        {
            animation = GetComponent<IAnimationWindow>();
            handlerClose += CloseEvent;
        }

        private void OnDestroy()
        {
            handlerClose -= CloseEvent;
        }

        public virtual void OnRefresh()
        {
            RefreshWindowHandler?.Invoke();
        }

        /// <summary>
        /// On Window open, add him to list in WindowAgregator
        /// </summary>
        public void OnOpen()
        {
            WindowAgregator.AddWindowHandler(this);
            Focus = true;
            transform.SetAsLastSibling();
        }

        /// <summary>
        /// Close Window Method. Call on button "ButtonClose" or on Escape button
        /// </summary>
        public void OnClose()
        {
            if (animation != null)
            {
                animation.OnCloseWinodwAnim(handlerClose);
            }
            else
            {
                WindowAgregator.RemoveWindowHandler(this);
            }
        }

        private void CloseEvent()
        {
            WindowAgregator.RemoveWindowHandler(this);
        }
    }
}
