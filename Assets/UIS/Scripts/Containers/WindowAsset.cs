namespace UIS
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Windows/Create New Asset Window", fileName = "AssetWindow", order = 0)]
    public class WindowAsset : ScriptableObject
    {
        [SerializeField]
        private Window window;

        public Window Window => window;
    }
}
