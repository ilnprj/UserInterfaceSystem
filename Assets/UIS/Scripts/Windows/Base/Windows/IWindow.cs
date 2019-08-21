// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS {
    /// <summary>
    /// Interface for base window type
    /// </summary>
    public interface IWindow
    {
        void OnOpen();

        void OnRefresh();

        void OnClose();
    }
}
