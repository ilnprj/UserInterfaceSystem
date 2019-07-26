// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    /// <summary>
    /// Class that is assigned to the close button of the window. The event is assigned automatically.
    /// </summary>
    public class ButtonClose : ButtonBaseBehaviour
    {
        /// <summary>
        /// Action sets automatically
        /// </summary>
        public override void Action()
        {
            if (window.Focus)
            {
                window.OnClose();
            }
        }
    }

}
