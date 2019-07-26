// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    /// <summary>
    /// Interface, that decides how windows will be loaded in memory
    /// </summary>
    public interface ILoadableWindow
    {
        WindowAsset GetWindowAsset(string idWindow);
    }
}
