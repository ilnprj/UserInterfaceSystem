// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    /// <summary>
    /// Class that loads the Assets of the windows previously unloaded into the inspector.
    /// </summary>
    public class LoadWindowInspector : MonoBehaviour, ILoadableWindow
    {
        public List<WindowAsset> WindowsForScene = new List<WindowAsset>();
        public WindowAsset GetWindowAsset(string idWindow)
        {
            return WindowsForScene.SingleOrDefault(obj => obj.name == idWindow);
        }
    }
}
