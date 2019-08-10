// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Windows/Create New Asset Window", fileName = "AssetWindow", order = 0)]
    public class WindowAsset : ScriptableObject
    {
        [SerializeField]
        private Window window = default;

        public Window Window => window;
    }
}
