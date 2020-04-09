// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    using UnityEngine.Events;

    public class ButtonActions : ButtonBaseBehaviour
    {
        public UnityEvent Events;
        protected override void Action()
        {
            if (window.Focus)
            {
                Events.Invoke();
            }
        }
    }
}
