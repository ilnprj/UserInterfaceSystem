// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    using System;

    public interface IAnimationWindow
    {
        void OnOpenWindowAnim();
        void OnCloseWinodwAnim(Action closeHandler);
    }
}
